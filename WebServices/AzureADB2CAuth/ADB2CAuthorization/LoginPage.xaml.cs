using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                // Look for existing account
                IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

                AuthenticationResult result = await App.AuthenticationClient.AcquireTokenSilentAsync(
                    Constants.Scopes,
                    accounts.FirstOrDefault());
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
            AuthenticationResult result;
            try
            {
                result = await App.AuthenticationClient.AcquireTokenAsync(
                    Constants.Scopes,
                    string.Empty,
                    UIBehavior.SelectAccount,
                    string.Empty,
                    App.UiParent);
                await Navigation.PushAsync(new LogoutPage(result));
            }
            catch (MsalException ex)
            {
                if (ex.Message != null && ex.Message.Contains("AADB2C90118"))
                {
                    result = await OnForgotPassword();
                    await Navigation.PushAsync(new LogoutPage(result));
                }
                else if (ex.ErrorCode != "authentication_canceled")
                {
                    await DisplayAlert("An error has occurred", "Exception message: " + ex.Message, "Dismiss");
                }
            }
        }

        async Task<AuthenticationResult> OnForgotPassword()
        {
            try
            {
                return await App.AuthenticationClient.AcquireTokenAsync(
                    Constants.Scopes,
                    string.Empty,
                    UIBehavior.SelectAccount,
                    string.Empty,
                    null,
                    Constants.AuthorityPasswordReset,
                    App.UiParent
                    );
            }
            catch (MsalException)
            {
                // Do nothing - ErrorCode will be displayed in OnLoginButtonClicked
                return null;
            }
        }
    }
}
