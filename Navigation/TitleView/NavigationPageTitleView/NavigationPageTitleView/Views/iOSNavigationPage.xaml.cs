using Xamarin.Forms;

namespace NavigationPageTitleView
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
