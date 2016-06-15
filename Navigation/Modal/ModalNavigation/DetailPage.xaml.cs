using System;
using Xamarin.Forms;

namespace ModalNavigation
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage ()
		{
			InitializeComponent ();
		}

		async void OnDismissButtonClicked (object sender, EventArgs args)
		{
			await Navigation.PopModalAsync ();
		}
	}
}
