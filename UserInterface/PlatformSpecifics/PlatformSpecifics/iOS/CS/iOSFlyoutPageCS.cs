using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSFlyoutPageCS : Xamarin.Forms.FlyoutPage
    {
        ICommand returnToPlatformSpecificsPage;

        public iOSFlyoutPageCS(ICommand restore)
        {
            returnToPlatformSpecificsPage = restore;

            Button shadowButton = new Button { Text = "Toggle Shadow" };
            shadowButton.Clicked += (s, e) => On<iOS>().SetApplyShadow(!On<iOS>().GetApplyShadow());

            Button returnButton = new Button { Text = "Return to platform-specifics list" };
            returnButton.Clicked += (s, e) => returnToPlatformSpecificsPage.Execute(null);

            On<iOS>().SetApplyShadow(true);

            Title = "FlyoutPage Shadow";
            Flyout = new ContentPage
            {
                Title = "Menu",
                BackgroundColor = Color.AliceBlue,
                Content = new StackLayout
                {
                    Margin = new Thickness(10,40,0,0),
                    Children =
                    {
                        new Label { Text = "Item 1" },
                        new Label { Text = "Item 2" },
                        new Label { Text = "Item 3" },
                        new Label { Text = "Item 4" },
                        new Label { Text = "Item 5" }
                    }
                }
            };

            Detail = new ContentPage
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(0,40,0,0),
                    Children =
                    {
                        new Label { Text = "This is the detail page.", HorizontalOptions = LayoutOptions.Center },
                        shadowButton,
                        returnButton
                    }
                }
            };
        }
    }
}

