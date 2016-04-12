using System;
using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public partial class Page2aXaml : ContentPage
	{
		public Page2aXaml ()
		{
			InitializeComponent ();
		}

		async void OnNextPageButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new Page3Xaml ());
		}

		async void OnPreviousPageButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopAsync ();
		}
	}
}
