using System;
using System.Threading.Tasks;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using TodoAzure.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthenticationProvider))]
namespace TodoAzure.iOS
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
                    user = await TodoItemManager.DefaultManager.CurrentClient.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, Constants.URLScheme);

                    if (user != null)
                    {
                        var authAlert = UIAlertController.Create("Authentication", "You are now logged in " + user.UserId, UIAlertControllerStyle.Alert);
                        authAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
                        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(authAlert, true, null);
                    }
                }
                success = true;
            }
            catch (Exception ex)
            {
                var authAlert = UIAlertController.Create("Authentication failed", ex.Message, UIAlertControllerStyle.Alert);
                authAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(authAlert, true, null);
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
                    foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
                    {
                        NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
                    }

                    await TodoItemManager.DefaultManager.CurrentClient.LogoutAsync();

                    var logoutAlert = UIAlertController.Create("Authentication", "You are now logged out " + user.UserId, UIAlertControllerStyle.Alert);
                    logoutAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(logoutAlert, true, null);
                }
                user = null;
                success = true;
            }
            catch (Exception ex)
            {
                var logoutAlert = UIAlertController.Create("Logout failed", ex.Message, UIAlertControllerStyle.Alert);
                logoutAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(logoutAlert, true, null);
            }
            return success;
        }
    }
}
