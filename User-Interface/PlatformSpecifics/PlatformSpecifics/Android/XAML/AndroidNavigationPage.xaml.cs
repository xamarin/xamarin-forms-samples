using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class AndroidNavigationPage : NavigationPage
    {
        public AndroidNavigationPage(Page page)
        {
            InitializeComponent();
            PushAsync(page);
        }
    }
}