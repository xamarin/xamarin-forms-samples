using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace ADB2CAuthorization
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			try
			{
				// Look for existing user
				var result = await App.AuthenticationClient.AcquireTokenSilentAsync(Constants.Scopes);
				await Navigation.PushAsync(new LogoutPage(result));
			}
			catch
			{
				// Do nothing - the user isn't logged in
			}
			base.OnAppearing();
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			try
			{
				var result = await App.AuthenticationClient.AcquireTokenAsync(
					Constants.Scopes,
					string.Empty,
					UiOptions.SelectAccount,
					string.Empty,
					null,
					Constants.Authority,
					Constants.SignUpSignInPolicy);
				await Navigation.PushAsync(new LogoutPage(result));
			}
			catch (MsalException ex)
			{
				if (ex.Message != null && ex.Message.Contains("AADB2C90118"))
				{
					await OnForgotPassword();
				}
				if (ex.ErrorCode != "authentication_canceled")
				{
					await DisplayAlert("An error has occurred", "Exception message: " + ex.Message, "Dismiss");
				}
			}
		}

		async Task OnForgotPassword()
		{
			try
			{
				await App.AuthenticationClient.AcquireTokenAsync(
					Constants.Scopes,
					string.Empty,
					UiOptions.SelectAccount,
					string.Empty,
					null,
					Constants.Authority,
					Constants.ResetPasswordPolicy);
			}
			catch (MsalException)
			{
				// Do nothing - ErrorCode will be displayed in OnLoginButtonClicked
			}
		}
	}
}
