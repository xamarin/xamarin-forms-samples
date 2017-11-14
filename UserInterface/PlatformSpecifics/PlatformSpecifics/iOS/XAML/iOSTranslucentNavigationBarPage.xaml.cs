using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSTranslucentNavigationBarPage : ContentPage
    {
        ICommand _returnToPlatformSpecificsPage;

        public iOSTranslucentNavigationBarPage(ICommand restore)
        {
            InitializeComponent();
            _returnToPlatformSpecificsPage = restore;
        }

        void OnTranslucentNavigationBarButtonClicked(object sender, EventArgs e)
        {
            (Application.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().SetIsNavigationBarTranslucent(!(Application.Current.MainPage as Xamarin.Forms.NavigationPage).On<iOS>().IsNavigationBarTranslucent());
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
