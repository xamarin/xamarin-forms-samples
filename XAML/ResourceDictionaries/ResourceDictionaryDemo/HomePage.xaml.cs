using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace ResourceDictionaryDemo
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

			object res;
			Application.Current.Resources.TryGetValue("ANormalStyle", out res);
			Debug.WriteLine("got it?");
		}

		async void OnNavigateButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ListDataPage ());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();


		}
	}
}