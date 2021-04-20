using Xamarin.Forms;

namespace StackLayoutDemos.Views
{
    public class AlignmentPageCS : ContentPage
    {
        public AlignmentPageCS()
        {
			Title = "Alignment demo";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children =
                {
					new Label { Text = "Start", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.Start },
					new Label { Text = "Center", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.Center },
					new Label { Text = "End", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.End },
					new Label { Text = "Fill", BackgroundColor = Color.Gray, HorizontalOptions = LayoutOptions.Fill }
				}
			};
		}
    }
}
