using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Xamarin.AppleSignIn
{
    public class AppleSignInClient
    {
        public AppleSignInClient(string serverId, string keyId, string teamId, Uri redirectUri, string p8FileContents, string state, string nonce)
        {
            ServerId = serverId;
            KeyId = keyId;
            TeamId = teamId;
            RedirectUri = redirectUri;
            P8FileContents = p8FileContents;
            State = state;
            Nonce = nonce;

            var scheme = redirectUri.Scheme.ToLowerInvariant();
            if (scheme != "http" && scheme != "https")
                throw new NotSupportedException("Your Redirect URI must be http:// or https:// and you should redirect to a server which securely has your Private Key stored to obtain the Access Token, and then redirect back to this app with it.");
        }

        public string KeyId { get; }
        public string TeamId { get; }
        public string ServerId { get; }
        public Uri RedirectUri { get;  }

        public string State { get; }

        public string Nonce { get; }

        public string P8FileContents { get; }

        internal const string AppleJwtUrl = "https://appleid.apple.com";

        internal const string AppleAuthorizationUrl = "https://appleid.apple.com/auth/authorize";

        internal const string AppleTokenUrl = "https://appleid.apple.com/auth/token";

        public virtual Uri GenerateAuthorizationUrl()
        {
            var respType = "code";

            var p = new Dictionary<string, string>
            {
                { "response_type", respType },
                { "response_mode", "form_post" },
                { "client_id", ServerId },
                { "redirect_uri", RedirectUri.OriginalString },
                { "nonce", Nonce },
                { "state", State },
                { "scope", "name email" }
            };

            var qs = string.Empty;
            foreach (var i in p)
                qs += WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value) + "&";

            return new Uri(AppleAuthorizationUrl + "?" + qs.TrimEnd('&'));
        }

        public async Task<AppleAccount> ExchangeTokenAsync(string code)
        {
            var client = new HttpClient();
            var header = new ProductHeaderValue("Xamarin", "1.0");
            var userAgentHeader = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgentHeader);

            var secret = GenerateClientSecretJWT(P8FileContents);

            var resp = await client.PostAsync(AppleTokenUrl, new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "authorization_code" },
                    { "code", code },
                    { "redirect_uri", RedirectUri.OriginalString },
                    { "client_id", ServerId },
                    { "client_secret", secret },
                }));

            resp.EnsureSuccessStatusCode();

            var respData = await resp.Content.ReadAsStringAsync();

            var respProperties = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(respData);

            var idToken = JwtToken.Decode(respProperties["id_token"]);
            var accessToken = respProperties?["access_token"];
            var refreshToken = respProperties?["refresh_token"];

            string email = idToken.Payload.ContainsKey("email") ? idToken.Payload["email"]?.ToString() : null;
            string name = idToken.Payload.ContainsKey("name") ? idToken.Payload["name"]?.ToString() : null;

            // Validate id token
            if (!idToken.Issuer.Equals(AppleJwtUrl))
                throw new ProtocolViolationException($"Invalid id_token issuer received: Expected `{AppleJwtUrl}` but observed `{idToken.Issuer}`");

            if (!idToken.AccessTokenHash.Equals(Util.Sha256AtHash(accessToken)))
                throw new ProtocolViolationException("Access Token Hash did not match actual access token's hash");

            if (!idToken.Algorithm.Equals("RS256"))
                throw new ProtocolViolationException($"Invalid id_token algorithm returned: Expected `RS256` but observed `{idToken.Algorithm}`");

            // Verify audience claim
            if (!idToken.Audience.Equals(ServerId))
                throw new ProtocolViolationException($"The id_token 'aud' claim does not match the provided clientId value.")
;
            if (idToken.Expiration < DateTime.UtcNow)
                throw new ProtocolViolationException($"The id_token is expired");

            // TODO: Verify the signature of the JWT token

            return new AppleAccount
            {
                Email = email,
                Name = name,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                IdToken = idToken
            };
        }

        public string GenerateClientSecretJWT(string p8FileContents)
        {
            var now = new DateTimeOffset(DateTime.UtcNow);

            var headers = new Dictionary<string, object>
                {
                    {  "alg", "ES256" },
                    {  "kid", KeyId }
                };

            var payload = new Dictionary<string, object>
                {
                    { "iss", TeamId },
                    { "iat", now.ToUnixTimeSeconds() },
                    { "exp", now.AddHours(1).ToUnixTimeSeconds() },
                    { "aud", AppleJwtUrl},
                    { "sub", ServerId }
                };

            //var secretKeyLines = p8FileContents.Split('\n').ToList();
            //var secretKey = string.Concat(secretKeyLines.Where(l =>
            //                    !l.StartsWith("--", StringComparison.OrdinalIgnoreCase)
            //                    && !l.EndsWith("--", StringComparison.OrdinalIgnoreCase)));

            var secretKey = CleanP8Key(p8FileContents);

            // Get our headers/payloads into a json string
            var headerStr = "{" + string.Join(",", headers.Select(kvp => $"\"{kvp.Key}\":\"{kvp.Value.ToString()}\"")) + "}";
            var payloadStr = "{";
            foreach (var kvp in payload)
            {
                if (kvp.Value is int || kvp.Value is long || kvp.Value is double)
                    payloadStr += $"\"{kvp.Key}\":{kvp.Value.ToString()},";
                else
                    payloadStr += $"\"{kvp.Key}\":\"{kvp.Value.ToString()}\",";
            }
            payloadStr = payloadStr.TrimEnd(',') + "}";


            // Load the key text
            var key = CngKey.Import(Convert.FromBase64String(secretKey), CngKeyBlobFormat.Pkcs8PrivateBlob);

            using (var dsa = new ECDsaCng(key))
            {
                var unsignedJwt = Base64UrlEncode(Encoding.UTF8.GetBytes(headerStr))
                                        + "." + Base64UrlEncode(Encoding.UTF8.GetBytes(payloadStr));

                var signature = dsa.SignData(Encoding.UTF8.GetBytes(unsignedJwt), HashAlgorithmName.SHA256);

                return unsignedJwt + "." + Base64UrlEncode(signature);
            }
        }

        static string CleanP8Key(string p8Contents)
        {
            // Remove whitespace
            var tmp = Regex.Replace(p8Contents, "\\s+", string.Empty, RegexOptions.Singleline);

            // Remove `---- BEGIN PRIVATE KEY ----` bits
            tmp = Regex.Replace(tmp, "-{1,}.*?-{1,}", string.Empty, RegexOptions.Singleline);

            return tmp;
        }

        static string Base64UrlEncode(byte[] data)
        {
            var base64 = Convert.ToBase64String(data, 0, data.Length);
            var base64Url = new StringBuilder();

            foreach (var c in base64)
            {
                if (c == '+')
                    base64Url.Append('-');
                else if (c == '/')
                    base64Url.Append('_');
                else if (c == '=')
                    break;
                else
                    base64Url.Append(c);
            }

            return base64Url.ToString();
        }
    }
}
