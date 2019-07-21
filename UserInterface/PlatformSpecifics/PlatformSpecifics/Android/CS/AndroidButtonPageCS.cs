using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidButtonPageCS : ContentPage
    {
        public AndroidButtonPageCS()
        {
			var button1 = new Xamarin.Forms.Button { Text = "Button", BackgroundColor = Color.Bisque, TextColor = Color.Blue, CornerRadius = 50, HeightRequest = 100, WidthRequest = 100, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			var button2 = new Xamarin.Forms.Button { Text = "Button", BackgroundColor = Color.Bisque, TextColor = Color.Blue, CornerRadius = 50, HeightRequest = 100, WidthRequest = 100, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			button2.On<Android>().SetUseDefaultPadding(true).SetUseDefaultShadow(true);

			Title = "Button Default Padding and Shadow";
            Content = new StackLayout
            {
				Margin = new Thickness(20),
                Children = 
				{
					new Label { Text = "The following buttons have identical definitions, except that the second button uses the default padding and default shadow platform-specifics." },
                    new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
                        Children = 
						{
							button1, button2
						}
					}
                }
            };
        }
    }
}
