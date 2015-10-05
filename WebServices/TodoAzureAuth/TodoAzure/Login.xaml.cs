using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using System.Linq;

namespace AzureTodo
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

		async void OnLoginClicked (object sender, EventArgs e)
		{
			MobileServiceUser user;

			try {
                // The authentication provider could also be Facebook, Twitter, or Microsoft
				user = await DependencyService.Get<IMobileClient> ().LoginAsync (MobileServiceAuthenticationProvider.Google);
				Navigation.InsertPageBefore (new TodoList (), this);
				await Navigation.PopAsync ();
			} catch (InvalidOperationException ex) {
				if (ex.Message.Contains ("Authentication was cancelled")) {
					messageLabel.Text = "Authentication cancelled by the user";
				}
			} catch (Exception ex) {
				messageLabel.Text = "Authentication failed";
			}
		}
	}
}
