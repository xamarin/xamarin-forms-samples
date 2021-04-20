using System;
using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSTranslucentTabbedPage : Xamarin.Forms.TabbedPage
    {
        ICommand returnToPlatformSpecificsPage;

        public iOSTranslucentTabbedPage(ICommand restore)
        {
            InitializeComponent();
            returnToPlatformSpecificsPage = restore;
        }

        void OnToggleButtonClicked(object sender, EventArgs e)
        {
            switch (On<iOS>().GetTranslucencyMode())
            {
                case TranslucencyMode.Default:
                    On<iOS>().SetTranslucencyMode(TranslucencyMode.Translucent);
                    break;
                case TranslucencyMode.Translucent:
                    On<iOS>().SetTranslucencyMode(TranslucencyMode.Opaque);
                    break;
                case TranslucencyMode.Opaque:
                    On<iOS>().SetTranslucencyMode(TranslucencyMode.Default);
                    break;
            }
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
