using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSTranslucentNavigationBarPageCS : ContentPage
    {
        public iOSTranslucentNavigationBarPageCS(ICommand restore)
        {
            var translucentButton = new Button { Text = "Toggle Translucent Navigation Bar" };
            translucentButton.Clicked += (sender, e) => (App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().SetIsNavigationBarTranslucent(!(App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().IsNavigationBarTranslucent());

            var colorModeButton = new Button { Text = "Toggle Status Bar Text Color Mode" };
            colorModeButton.Clicked += (sender, e) =>
            {
                switch ((App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().GetStatusBarTextColorMode())
                {
                    case StatusBarTextColorMode.MatchNavigationBarTextLuminosity:
                        (App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.DoNotAdjust);
                        break;
                    case StatusBarTextColorMode.DoNotAdjust:
                        (App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.MatchNavigationBarTextLuminosity);
                        break;
                }
            };

            var returnButton = new Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => restore.Execute(null);

            Title = "Navigation Bar";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { translucentButton, colorModeButton, returnButton }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            (App.Current.MainPage as Xamarin.Forms.NavigationPage).BackgroundColor = Color.Blue;
            (App.Current.MainPage as Xamarin.Forms.NavigationPage).BarTextColor = Color.Black;
            (App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().EnableTranslucentNavigationBar();
            (App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.DoNotAdjust);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            (App.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().DisableTranslucentNavigationBar();
        }
    }
}
