using System;
using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSMasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        ICommand returnToPlatformSpecificsPage;

        public iOSMasterDetailPage(ICommand restore)
        {
            InitializeComponent();
            returnToPlatformSpecificsPage = restore;
        }

        void OnShadowButtonClicked(object sender, EventArgs e)
        {
            bool isShadow = On<iOS>().GetApplyShadow();
            On<iOS>().SetApplyShadow(!isShadow);
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
