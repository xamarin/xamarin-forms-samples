using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSScrollViewPage : MasterDetailPage
    {
        public iOSScrollViewPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            scrollView.On<iOS>().SetShouldDelayContentTouches(!scrollView.On<iOS>().ShouldDelayContentTouches());
        }
    }
}
