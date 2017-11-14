using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSStatusBarTextColorModePage : MasterDetailPage
    {
        ICommand _returnToPlatformSpecificsPage;

        public iOSStatusBarTextColorModePage(ICommand restore)
        {
            InitializeComponent();
            _returnToPlatformSpecificsPage = restore;

            IsPresentedChanged += (sender, e) =>
            {
                var mdp = sender as MasterDetailPage;
                if (mdp.IsPresented)
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.DoNotAdjust);
                else
                    ((Xamarin.Forms.NavigationPage)mdp.Detail).On<iOS>().SetStatusBarTextColorMode(StatusBarTextColorMode.MatchNavigationBarTextLuminosity);
            };
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
