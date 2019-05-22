using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSHideHomeIndicatorPage : ContentPage
    {
        public iOSHideHomeIndicatorPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            On<iOS>().SetPrefersHomeIndicatorAutoHidden(!On<iOS>().PrefersHomeIndicatorAutoHidden());
        }
    }
}
