using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidElevationPageCS : ContentPage
    {
        public AndroidElevationPageCS()
        {
            var outputLabel = new Label();
            var aboveButton = new Button { Text = "Button Above BoxView - Click Me" };
            aboveButton.Clicked += (sender, e) => outputLabel.Text = "The bottom button can receive input, while the top button cannot.";
            aboveButton.On<Android>().SetElevation(10);

            Title = "Elevation";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Grid
                    {
                        Children = {
                            new Button { Text = "Button Beneath BoxView" },
                            new BoxView { Color = Color.Red, Opacity = 0.2, HeightRequest = 50 }
                        }
                    },
                    new Grid
                    {
                        Margin = new Thickness(0,20,0,0),
                        Children = {
                            aboveButton,
                            new BoxView { Color = Color.Red, Opacity = 0.2, HeightRequest = 50 }
                        }
                    },
                    outputLabel
                }
            };
        }
    }
}
