using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Xamarin.AppleSignIn
{
    public class JwtToken
    {
        public string Raw { get; set; }

        public string Signature { get; set; }

        public Dictionary<string, object> Header { get; set; }

        public Dictionary<string, object> Payload { get; set; }

        public string Algorithm
            => Header.ContainsKey("alg") ? Header["alg"]?.ToString() : null;

        public string Type
            => Header.ContainsKey("typ") ? Header["typ"]?.ToString() : null;

        public string Issuer
            => Payload.ContainsKey("iss") ? Payload["iss"]?.ToString() : null;

        public string Subject
            => Payload.ContainsKey("sub") ? Payload["sub"]?.ToString() : null;

        public string Audience
            => Payload.ContainsKey("aud") ? Payload["aud"]?.ToString() : null;

        public string TokenId
            => Payload.ContainsKey("jti") ? Payload["jti"]?.ToString() : null;

        public string AccessTokenHash
            => Payload.ContainsKey("at_hash") ? Payload["at_hash"]?.ToString() : null;

        public string Nonce
            => Payload.ContainsKey("nonce") ? Payload["nonce"]?.ToString() : null;

        public DateTimeOffset Expiration
        {
            get
            {
                if (Payload.ContainsKey("exp") && int.TryParse(Payload["exp"].ToString(), out var seconds))
                    return DateTimeOffset.FromUnixTimeSeconds(seconds);

                return DateTimeOffset.MinValue;
            }
        }

        public DateTimeOffset Issued
        {
            get
            {
                if (Payload.ContainsKey("iat") && int.TryParse(Payload["iat"].ToString(), out var seconds))
                    return DateTimeOffset.FromUnixTimeSeconds(seconds);

                return DateTimeOffset.MinValue;
            }
        }

        public DateTimeOffset NotBefore
        {
            get
            {
                if (Payload.ContainsKey("nbf") && int.TryParse(Payload["nbf"].ToString(), out var seconds))
                    return DateTimeOffset.FromUnixTimeSeconds(seconds);

                return DateTimeOffset.MinValue;
            }
        }

        public bool Validate(string expectedClientId, string expectedAlgorithm, string expectedIssuer, string accessToken = null)
        {
            // verify signature
            if (!Algorithm.Equals(expectedAlgorithm, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(Algorithm), $"The id_token 'alg' does not match the expected algorithm value.  Expected '{expectedAlgorithm}' but found '{Algorithm}'.");

            //TODO: Validate signature

            // Verify expiration claim
            if (Expiration < DateTime.UtcNow)
                throw new ArgumentOutOfRangeException(nameof(Expiration), $"The id_token is expired");

            // Verify issuer claim
            if (!Issuer.Equals(expectedIssuer, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(Issuer), $"The id_token 'iss' claim does not match expected issuer value.  Expected '{expectedIssuer}' but fond '{Issuer}'.");

            // Verify audience claim
            if (!Audience.Equals(expectedClientId, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(Audience), $"The id_token 'aud' claim does not match the provided clientId value.")
;
            // Verify Access Token Hash claim (if provided)
            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(AccessTokenHash))
            {
                var atHash = Util.Sha256AtHash(accessToken);

                if (!AccessTokenHash.Equals(atHash, StringComparison.Ordinal))
                    throw new ArgumentOutOfRangeException(nameof(AccessTokenHash), $"The id_token 'at_hash' claim does not match the expected hash of the given token.  Expected {atHash} but found {AccessTokenHash}");
            }

            return true;
        }

        public static JwtToken Decode(string encodedJwt)
        {
            JwtToken result = null;

            if (!string.IsNullOrEmpty(encodedJwt) && encodedJwt.Contains("."))
            {
                result = new JwtToken();

                result.Raw = encodedJwt;

                var parts = encodedJwt.Split(new char[] { '.' }, 3);

                if (parts.Length == 3)
                {
                    var headerJson = Encoding.UTF8.GetString(Util.Base64UrlDecode(parts[0]));
                    result.Header = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(headerJson) ?? new Dictionary<string, object>();

                    var payloadJson = Encoding.UTF8.GetString(Util.Base64UrlDecode(parts[1]));
                    result.Payload = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(payloadJson) ?? new Dictionary<string, object>();

                    result.Signature = parts[2];
                }
            }

            return result;
        }
    }
}
