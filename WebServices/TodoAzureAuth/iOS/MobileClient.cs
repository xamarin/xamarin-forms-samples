using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using AzureTodo.iOS;
using UIKit;
using Foundation;

[assembly: Xamarin.Forms.Dependency (typeof(MobileClient))]

namespace AzureTodo.iOS
{
	public class MobileClient : IMobileClient
	{
		public async Task<MobileServiceUser> LoginAsync (MobileServiceAuthenticationProvider provider)
		{
			var view = UIApplication.SharedApplication.KeyWindow.RootViewController;
			return await App.Client.LoginAsync (view, provider);
		}

		public void Logout ()
		{
			foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies) {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }
			
			App.Client.Logout ();
		}
	}
}
