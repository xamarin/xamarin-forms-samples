using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSStatusBarTextColorModePageCS : MasterDetailPage
    {
        public iOSStatusBarTextColorModePageCS()
        {
            Master = new ContentPage { Title = "Master Page Title" };
            Detail = new Xamarin.Forms.NavigationPage(new ContentPage
            {
                Content = new Label { Text = "Slide the master page to see the status bar text color mode change." }
            });

            ((Xamarin.Forms.NavigationPage)Detail).BarBackgroundColor = Color.Blue;
            ((Xamarin.Forms.NavigationPage)Detail).BarTextColor = Color.White;

            IsPresentedChanged += (sender, e) =>
            {
                var mdp = sender as MasterDetailPage;
                if (mdp.IsPresented)
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.DoNotAdjust);
                else
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.MatchNavigationBarTextLuminosity);
            };
        }
    }
}
