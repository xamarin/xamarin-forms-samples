using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.AppleSignIn
{
    public class AppleAccount
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public JwtToken IdToken { get; set; }
        public string RealUserStatus { get; set; }
        public string UserId { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public string ToQueryParameters()
            => $"access_token={AccessToken}&refresh_token={RefreshToken}&id_token={IdToken.Raw}";

        public static AppleAccount FromUrl(string url)
        {
            var parameters = Util.ParseUrlParameters(url);

            var idToken = JwtToken.Decode(parameters["id_token"]);

            return new AppleAccount
            {
                IdToken = idToken,
                UserId = idToken.Subject,
                Email = idToken.Payload.ContainsKey("email") ? idToken.Payload["email"]?.ToString() : null,
                Name = idToken.Payload.ContainsKey("name") ? idToken.Payload["name"]?.ToString() : null,
                AccessToken = parameters.ContainsKey("access_token") ? parameters["access_token"] : null,
                RefreshToken = parameters.ContainsKey("refresh_token") ? parameters["refresh_token"] : null,
            };
        }
    }
}
