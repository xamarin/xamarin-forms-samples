using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Android.Webkit;
using AzureTodo.Droid;

[assembly: Xamarin.Forms.Dependency (typeof(MobileClient))]
	
namespace AzureTodo.Droid
{
	public class MobileClient : IMobileClient
	{
		public async Task<MobileServiceUser> LoginAsync (MobileServiceAuthenticationProvider provider)
		{
			return await App.Client.LoginAsync (Forms.Context, provider);
		}

		public void Logout ()
		{
			CookieManager.Instance.RemoveAllCookie ();
			App.Client.Logout ();
		}
	}
}
