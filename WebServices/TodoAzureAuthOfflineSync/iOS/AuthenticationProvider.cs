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
					user = await TodoItemManager.DefaultManager.CurrentClient.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.Google);

					if (user != null)
					{
						var authAlert = new UIAlertView("Authentication", "You are now logged in " + user.UserId, null, "OK", null);
						authAlert.Show();
					}
				}
				success = true;
			}
			catch (Exception ex)
			{
				var authAlert = new UIAlertView("Authentication failed", ex.Message, null, "OK", null);
				authAlert.Show();
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
					var logoutAlert = new UIAlertView("Authentication", "You are now logged out " + user.UserId, null, "OK", null);
					logoutAlert.Show();
				}
				user = null;
				success = true;
			}
			catch (Exception ex)
			{
				var logoutAlert = new UIAlertView("Logout failed", ex.Message, null, "OK", null);
				logoutAlert.Show();
			}
			return success;
		}
	}
}
