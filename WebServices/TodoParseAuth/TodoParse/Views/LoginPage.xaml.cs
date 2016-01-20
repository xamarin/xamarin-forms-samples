using System;

using Xamarin.Forms;

namespace TodoParse
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

		async void OnSignUpClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SignUpPage ());
		}

		async void OnLoginClicked (object sender, EventArgs e)
		{
			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			};

			var result = await App.TodoManager.LoginUserAsync (user);

			if (result) {
				Navigation.InsertPageBefore (new TodoListPage (), this);
				await Navigation.PopAsync ();
			} else {
				messageLabel.Text = "Login failed";
			}
		}
	}
}