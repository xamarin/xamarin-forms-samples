using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSNavigationPage : NavigationPage
    {
        public iOSNavigationPage(Page page)
        {
            InitializeComponent();
            PushAsync(page);
        }
    }
}
