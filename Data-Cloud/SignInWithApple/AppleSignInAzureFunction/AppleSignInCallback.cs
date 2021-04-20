using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using Xamarin.AppleSignIn;

namespace AppleSignInAzureFunction
{
    public static class AppleSignInCallback
    {
        [FunctionName("applesignin_callback")]
        public static async Task<IActionResult> Callback(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // Get the auth code we need to exchange for the token
            var code = req.Form?["code"] ?? req.Query?["code"];

            // Get the state returned from the originating auth request
            // TODO: IMPORTANT You should look the state up from the auth function called previous
            // and only proceed if it exists in the look up table to ensure it's a genuine
            // request originating from the auth function.
            var state = req.Form?["state"] ?? req.Query?["state"];

            // We can use the Apple OAuth provider for exchanging the auth code for the access token
            var apple = new AppleSignInClient(Config.ServerId, Config.KeyId, Config.TeamId, new Uri(Config.RedirectUri), Config.P8FileContents, state, null);

            // Exchange for the token
            var account = await apple.ExchangeTokenAsync(code);

            // Build our redirect URI and attach the properties to it to send back to the app
            var url = $"{Config.AppCallbackUri}#{account.ToQueryParameters()}";

            return new RedirectResult(url, false);
        }
    }
}
