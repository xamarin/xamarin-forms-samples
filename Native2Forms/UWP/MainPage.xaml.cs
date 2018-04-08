using Phoneword.UWP.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms.Platform.UWP;

namespace Phoneword.UWP
{
    public sealed partial class MainPage : Page
    {
        public static MainPage Instance;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            Instance = this;
            this.Content = new Phoneword.UWP.Views.PhonewordPage().CreateFrameworkElement();
        }

        public void NavigateToCallHistoryPage()
        {
            this.Frame.Navigate(new CallHistoryPage());
        }
    }
}
