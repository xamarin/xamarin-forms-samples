using Xamarin.Forms;

namespace StackLayoutDemos.Views
{
    public class ExpansionPageCS : ContentPage
    {
        public ExpansionPageCS()
        {
			Title = "Expansion demo";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
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
