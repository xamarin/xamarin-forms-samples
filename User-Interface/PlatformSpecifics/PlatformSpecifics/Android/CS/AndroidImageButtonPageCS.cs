using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidImageButtonPageCS : ContentPage
    {
        public AndroidImageButtonPageCS()
        {
            var imageButton = new Xamarin.Forms.ImageButton { Source = "XamarinLogo.png", BackgroundColor = Color.GhostWhite, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
            imageButton.Clicked += (sender, e) => imageButton.On<Android>().SetIsShadowEnabled(!imageButton.On<Android>().GetIsShadowEnabled());

            imageButton.On<Android>()
                       .SetIsShadowEnabled(true)
                       .SetShadowColor(Color.Gray)
                       .SetShadowOffset(new Size(10, 10))
                       .SetShadowRadius(12);

            Title = "Android ImageButton";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    imageButton,
                    new Label { Text = "Tap the ImageButton to toggle the shadow effect.", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), HorizontalOptions = LayoutOptions.Center }
                }
            };
        }
    }
}
