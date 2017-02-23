using Xamarin.Forms;

namespace LayoutOptionsDemo
{
	public class LayoutOptionsAlignmentPageCS : ContentPage
	{
		public LayoutOptionsAlignmentPageCS()
		{
			Title = "Alignment";
			Icon = "csharp.png";

			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					new Label { Text = "LayoutOptions - Alignment", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
					new Label { Text = "Start", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.Start },
					new Label { Text = "Center", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.Center },
					new Label { Text = "End", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.End },
					new Label { Text = "Fill", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.Fill }
				}
			};
		}
	}
}
