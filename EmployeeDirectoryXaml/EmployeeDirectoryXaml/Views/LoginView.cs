using System;
using Xamarin.Forms;
using EmployeeDirectory.Data;
using EmployeeDirectory.ViewModels;

namespace EmployeeDirectory
{
	public class LoginView : ContentPage
	{
		private LoginViewModel loginViewModel;

		private LoginViewModel Model {
			get {
				if (loginViewModel == null)
					loginViewModel = new LoginViewModel (App.Service);

				return loginViewModel;
			}
		}

		private Image TitleImage {
			get {
				return new Image { 
					Source = FileImageSource.FromFile ("logo")
				};
			}
		}

		private Entry UsernameEntry {
			get {
				var usernameEntry = new Entry { 
					Placeholder = "Username",
				};

				usernameEntry.SetBinding (Entry.TextProperty, "Username");
				return usernameEntry;
			}
		}

		private Entry PasswordEntry {
			get {
				var passwordEntry = new Entry () { 
					IsPassword = true,
					Placeholder = "Password"
				};

				passwordEntry.SetBinding (Entry.TextProperty, "Password");
				return passwordEntry;
			}
		}

		private Button LoginButton {
			get {
				var loginButton = new Button { Text = "Login" };
				loginButton.Clicked += OnLoginClicked;
				return loginButton;
			}
		}

		private Button HelpButton {
			get {
				var helpButton = new Button () { Text = "Help" };
				helpButton.Clicked += OnHelpClicked;
				return helpButton;
			}
		}

		public LoginView ()
		{
			BindingContext = Model;

			var grid = new Grid () {
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			if (Device.OS == TargetPlatform.iOS) {
				grid.Children.Add (LoginButton, 0, 0);
				grid.Children.Add (HelpButton, 1, 0);

				Content = new StackLayout () { 
					VerticalOptions = LayoutOptions.StartAndExpand,
					Padding = new Thickness (30),
					Children = { TitleImage, UsernameEntry, PasswordEntry, grid }
				};

				BackgroundImage = "login_box";

			} else if (Device.OS == TargetPlatform.Android) {
				grid.Children.Add (TitleImage, 0, 0);
				grid.Children.Add (HelpButton, 1, 0);

				Content = new StackLayout () {
					VerticalOptions = LayoutOptions.CenterAndExpand,
					Padding = new Thickness (30),
					Children = { grid, UsernameEntry, PasswordEntry, LoginButton }
				};
			}

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
		}

		void OnLoginClicked (object sender, EventArgs e)
		{
			if (loginViewModel.CanLogin ()) {
				loginViewModel
				.LoginAsync (System.Threading.CancellationToken.None)
				.ContinueWith (_ => {
					App.LastUseTime = System.DateTime.UtcNow;

					Navigation.PopModal ();
				});

				Navigation.PopModal ();
			} else {
				DisplayAlert ("Error", loginViewModel.ValidationErrors, "OK", null);
			}
		}

		void OnHelpClicked (object sender, EventArgs e)
		{
			DisplayAlert ("Help", "Enter any username and password", "OK", null);
		}
	}
}

