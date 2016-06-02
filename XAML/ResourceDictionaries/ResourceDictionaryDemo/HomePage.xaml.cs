using System;
using Xamarin.Forms;

namespace ResourceDictionaryDemo
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

		async void OnNavigateButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ListDataPage ());
		}
	}
}

