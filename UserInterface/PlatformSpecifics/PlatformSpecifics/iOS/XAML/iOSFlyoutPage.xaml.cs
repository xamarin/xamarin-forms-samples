using System;
using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSFlyoutPage : Xamarin.Forms.FlyoutPage
    {
        ICommand returnToPlatformSpecificsPage;

        public iOSFlyoutPage(ICommand restore)
        {
            InitializeComponent();
            returnToPlatformSpecificsPage = restore;
        }

        void OnShadowButtonClicked(object sender, EventArgs e)
        {
            On<iOS>().SetApplyShadow(!On<iOS>().GetApplyShadow());
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
