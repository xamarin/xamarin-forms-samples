using Foundation;
using System.Linq;
using TodoAWSSimpleDB.iOS;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency (typeof(Authentication))]

namespace TodoAWSSimpleDB.iOS
{
	public class Authentication : IAuthentication
	{
		public void Logout ()
		{
            foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies) {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }

			var accounts = AccountStore.Create ().FindAccountsForService (App.AppName);
			var account = accounts.FirstOrDefault ();

			if (account != null) {
				AccountStore.Create ().Delete (account, App.AppName);
				App.User = null;
			}
		}
	}
}
