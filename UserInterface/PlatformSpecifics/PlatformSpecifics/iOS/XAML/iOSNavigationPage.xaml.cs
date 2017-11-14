using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSNavigationPage : Xamarin.Forms.NavigationPage
    {
        public iOSNavigationPage(ICommand restore)
        {
            InitializeComponent();
            PushAsync(new iOSTranslucentNavigationBarPage(restore));
        }
    }
}
