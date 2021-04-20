using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSHideHomeIndicatorPageCS : ContentPage
    {
        public iOSHideHomeIndicatorPageCS()
        {
            Button button = new Button { Text = "Toggle Home Indicator" };
            button.Clicked += (sender, e) => On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden());

            On<iOS>().SetPrefersHomeIndicatorAutoHidden(true);

            Title = "Hide Home Indicator";
            Content = new StackLayout
            {
                Margin = new Thickness(20,35,20,20),
                Children = 
                {
                    new Label { Text = "Tap the button below to toggle the home indicator on iPhone X, XR, and XS models." },
                    button
                }
            };
        }
    }
}
