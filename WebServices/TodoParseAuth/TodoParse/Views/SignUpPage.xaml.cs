using System;
using System.Linq;
using Xamarin.Forms;

namespace TodoParse
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

		async void OnSignUpClicked (object sender, EventArgs e)
		{
			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				Email = emailEntry.Text
			};

			var result = await App.TodoManager.SignUpUserAsync (user);
			if (result) {
				Navigation.InsertPageBefore (new TodoListPage (), Navigation.NavigationStack.First ());
				await Navigation.PopToRootAsync ();
			} else {
				messageLabel.Text = "Sign up failed";
			}
		}
	}
}
