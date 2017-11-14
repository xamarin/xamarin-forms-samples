using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSScrollViewPage : MasterDetailPage
    {
        ICommand _returnToPlatformSpecificsPage;

        public iOSScrollViewPage(ICommand restore)
        {
            InitializeComponent();
            _returnToPlatformSpecificsPage = restore;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            scrollView.On<iOS>().SetShouldDelayContentTouches(!scrollView.On<iOS>().ShouldDelayContentTouches());
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
