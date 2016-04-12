using System;
using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class Page1 : ContentPage
	{
		public Page1 ()
		{
			var nextPageButton = new Button { Text = "Next Page", VerticalOptions = LayoutOptions.CenterAndExpand };
			nextPageButton.Clicked += OnNextPageButtonClicked;

			Title = "Page 1";
			Content = new StackLayout { 
				Children = {
					nextPageButton
				}
			};
		}

		async void OnNextPageButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new Page2 ());
		}
	}
}
