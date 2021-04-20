using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSModalPagePresentationStyleCS : ContentPage
    {
        public iOSModalPagePresentationStyleCS()
        {
            On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.OverFullScreen);

            var button = new Button { Text = "Return to Platform-Specifics List" };
            button.Clicked += async (sender, e) =>
            {
                await Navigation.PopModalAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20,35,20,20),
                Children = {
                    new Label { Text = "Modal popup as a form sheet.", HorizontalOptions = LayoutOptions.Center },
                    button
                }
            };
        }
    }
}
