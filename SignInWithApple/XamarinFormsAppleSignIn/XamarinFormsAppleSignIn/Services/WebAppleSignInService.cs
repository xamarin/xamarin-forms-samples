using System;
using System.Threading.Tasks;
using Xamarin.AppleSignIn;

namespace XamarinFormsAppleSignIn.Services
{
    public interface IAppleSignInService
    {
        bool Callback(string url);

        Task<AppleAccount> SignInAsync();
    }

    public class WebAppleSignInService : IAppleSignInService
    {
        // IMPORTANT: This is what you register each native platform's url handler to be
        public const string CallbackUriScheme = "xamarinformsapplesignin";
        public const string InitialAuthUrl = "http://local.test:7071/api/applesignin_auth";

        string currentState;
        string currentNonce;

        TaskCompletionSource<AppleAccount> tcsAccount = null;

        public bool Callback(string url)
        {
            // Only handle the url with our callback uri scheme
            if (!url.StartsWith(CallbackUriScheme + "://"))
                return false;

            // Ensure we have a task waiting
            if (tcsAccount != null && !tcsAccount.Task.IsCompleted)
            {
                try
                {
                    // Parse the account from the url the app opened with
                    var account = AppleAccount.FromUrl(url);

                    // IMPORTANT: Validate the nonce returned is the same as our originating request!!
                    if (!account.IdToken.Nonce.Equals(currentNonce))
                        tcsAccount.TrySetException(new InvalidOperationException("Invalid or non-matching nonce returned"));

                    // Set our account result
                    tcsAccount.TrySetResult(account);
                }
                catch (Exception ex)
                {
                    tcsAccount.TrySetException(ex);
                }
            }

            tcsAccount.TrySetResult(null);
            return false;
        }

        public async Task<AppleAccount> SignInAsync()
        {
            tcsAccount = new TaskCompletionSource<AppleAccount>();

            // Generate state and nonce which the server will use to initial the auth
            // with Apple.  The nonce should flow all the way back to us when our function
            // redirects to our app
            currentState = Util.GenerateState();
            currentNonce = Util.GenerateNonce();

            // Start the auth request on our function (which will redirect to apple)
            // inside a browser (either SFSafariViewController, Chrome Custom Tabs, or native browser)
            await Xamarin.Essentials.Browser.OpenAsync($"{InitialAuthUrl}?&state={currentState}&nonce={currentNonce}",
                Xamarin.Essentials.BrowserLaunchMode.SystemPreferred);

            return await tcsAccount.Task;
        }
    }
}