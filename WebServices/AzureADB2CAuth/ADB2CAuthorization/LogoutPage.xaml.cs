using System;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace ADB2CAuthorization
{
	public partial class LogoutPage : ContentPage
	{
		AuthenticationResult authenticationResult;

		public LogoutPage(AuthenticationResult result)
		{
			InitializeComponent();
			authenticationResult = result;
		}

		protected override void OnAppearing()
		{
			if (authenticationResult != null)
			{
				if (authenticationResult.User.Name != "unknown")
				{
					messageLabel.Text = string.Format("Welcome {0}", authenticationResult.User.Name);
				}
				else
				{
					messageLabel.Text = string.Format("UserId: {0}", authenticationResult.User.UniqueId);
				}
			}

			base.OnAppearing();
		}

		async void OnLogoutButtonClicked(object sender, EventArgs e)
		{
			App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
			await Navigation.PopAsync();
		}
	}
}

