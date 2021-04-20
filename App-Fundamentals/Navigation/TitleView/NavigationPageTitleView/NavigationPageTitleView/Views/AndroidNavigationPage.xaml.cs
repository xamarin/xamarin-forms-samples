using Xamarin.Forms;

namespace NavigationPageTitleView
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
