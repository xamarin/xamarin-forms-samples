using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSTitleViewNavigationPage : NavigationPage
    {
        public iOSTitleViewNavigationPage(Page page)
        {
            InitializeComponent();
            PushAsync(page);
        }
    }
}
