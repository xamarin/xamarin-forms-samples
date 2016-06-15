using System;
using Xamarin.Forms;

namespace LoginNavigation
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SignUpPage ());
		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
			var user = new User {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			};

			var isValid = AreCredentialsCorrect (user);
			if (isValid) {
				App.IsUserLoggedIn = true;
				Navigation.InsertPageBefore (new MainPage (), this);
				await Navigation.PopAsync ();
			} else {
				messageLabel.Text = "Login failed";
				passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect (User user)
		{
			return user.Username == Constants.Username && user.Password == Constants.Password;
		}
	}
}
