using Xamarin.Forms;

namespace LayoutOptionsDemo
{
	public class LayoutOptionsExpansionPageCS : ContentPage
	{
		public LayoutOptionsExpansionPageCS()
		{
			Title = "Expansion";
			Icon = "csharp.png";

			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					new Label { Text = "LayoutOptions - Expansion", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
					new BoxView { BackgroundColor = Color.Red, HeightRequest = 1 },
					new Label { Text = "StartAndExpand", BackgroundColor = Color.Gray, VerticalOptions = LayoutOptions.StartAndExpand },
					new BoxView { BackgroundColor = Color.Red, HeightRequest = 1 },
					new Label { Text = "CenterAndExpand", BackgroundColor = Color.Gray, VerticalOptions = LayoutOptions.CenterAndExpand },
					new BoxView { BackgroundColor = Color.Red, HeightRequest = 1 },
					new Label { Text = "EndAndExpand", BackgroundColor = Color.Gray, VerticalOptions = LayoutOptions.EndAndExpand },
					new BoxView { BackgroundColor = Color.Red, HeightRequest = 1 },
					new Label { Text = "FillAndExpand", BackgroundColor = Color.Gray, VerticalOptions = LayoutOptions.FillAndExpand },
					new BoxView { BackgroundColor = Color.Red, HeightRequest = 1 }
				}
			};
		}
	}
}
