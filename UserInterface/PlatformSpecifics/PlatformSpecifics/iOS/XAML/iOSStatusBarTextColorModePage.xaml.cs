using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSStatusBarTextColorModePage : MasterDetailPage
    {
        public iOSStatusBarTextColorModePage()
        {
            InitializeComponent();

            IsPresentedChanged += (sender, e) =>
            {
                var mdp = sender as MasterDetailPage;
                if (mdp.IsPresented)
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.DoNotAdjust);
                else
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.MatchNavigationBarTextLuminosity);
            };
        }
    }
}
