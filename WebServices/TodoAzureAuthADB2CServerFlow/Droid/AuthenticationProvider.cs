using System;
using System.Threading.Tasks;
using Android.App;
using Android.Webkit;
using Microsoft.WindowsAzure.MobileServices;
using TodoAzure.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthenticationProvider))]
namespace TodoAzure.Droid
{
    public class AuthenticationProvider : IAuthenticate
    {
        MobileServiceUser user;

        public async Task<bool> AuthenticateAsync()
        {
            bool success = false;
            try
            {
                if (user == null)
                {
                    user = await TodoItemManager.DefaultManager.CurrentClient.LoginAsync(Forms.Context, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, Constants.URLScheme);
                    if (user != null)
                    {
                        CreateAndShowDialog(string.Format("You are now logged in - {0}", user.UserId), "Logged in!");
                    }
                }
                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Authentication failed");
            }
            return success;
        }

        public async Task<bool> LogoutAsync()
        {
            bool success = false;
            try
            {
                if (user != null)
                {
                    CookieManager.Instance.RemoveAllCookie();
                    await TodoItemManager.DefaultManager.CurrentClient.LogoutAsync();
                    CreateAndShowDialog(string.Format("You are now logged out - {0}", user.UserId), "Logged out!");
                }
                user = null;
                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Logout failed");
            }

            return success;
        }

        void CreateAndShowDialog(string message, string title)
        {
            var builder = new AlertDialog.Builder(Forms.Context);
            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.SetNeutralButton("OK", (sender, args) => { });
            builder.Create().Show();
        }
    }
}
