using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSNavigationPage : Xamarin.Forms.NavigationPage
    {
        public iOSNavigationPage()
        {
            InitializeComponent();
            PushAsync(new iOSTranslucentNavigationBarPage());
        }
    }
}
