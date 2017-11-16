using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSNavigationPage : Xamarin.Forms.NavigationPage
    {
        public iOSNavigationPage(Page page)
        {
            InitializeComponent();
            PushAsync(page);
        }
    }
}
