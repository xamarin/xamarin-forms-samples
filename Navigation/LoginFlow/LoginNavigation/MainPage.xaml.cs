using System;
using Xamarin.Forms;

namespace LoginNavigation
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		async void OnLogoutButtonClicked (object sender, EventArgs e)
		{
			App.IsUserLoggedIn = false;
			Navigation.InsertPageBefore (new LoginPage (), this);
			await Navigation.PopAsync ();
		}
	}
}
