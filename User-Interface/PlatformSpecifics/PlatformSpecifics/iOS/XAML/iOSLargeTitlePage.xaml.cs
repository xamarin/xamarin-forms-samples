using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSLargeTitlePage : ContentPage
    {
        ICommand _returnToPlatformSpecificsPage;

        public iOSLargeTitlePage(ICommand restore)
        {
            InitializeComponent();
            _returnToPlatformSpecificsPage = restore;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            switch (On<iOS>().LargeTitleDisplay())
            {
                case LargeTitleDisplayMode.Always:
                    On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Automatic);
                    break;
                case LargeTitleDisplayMode.Automatic:
                    On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Never);
                    break;
                case LargeTitleDisplayMode.Never:
                    On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
                    break;
            }
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
