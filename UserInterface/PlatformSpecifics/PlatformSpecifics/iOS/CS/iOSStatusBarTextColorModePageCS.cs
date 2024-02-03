using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSStatusBarTextColorModePageCS : Xamarin.Forms.FlyoutPage
    {
        public iOSStatusBarTextColorModePageCS(ICommand restore)
        {
            var returnButton = new Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => restore.Execute(null);

            Flyout = new ContentPage { Title = "FlyoutPage Title" };
            Detail = new Xamarin.Forms.NavigationPage(new ContentPage
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children = {
                        new Label { Text = "Slide the flyout page to see the status bar text color mode change." },
                        returnButton
                    }
                }
            });

            ((Xamarin.Forms.NavigationPage)Detail).BarBackgroundColor = Color.Blue;
            ((Xamarin.Forms.NavigationPage)Detail).BarTextColor = Color.White;

            IsPresentedChanged += (sender, e) =>
            {
                var mdp = sender as Xamarin.Forms.FlyoutPage;
                if (mdp.IsPresented)
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.DoNotAdjust);
                else
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.MatchNavigationBarTextLuminosity);
            };
        }
    }
}
