using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSSafeAreaPage : ContentPage
    {
        public iOSSafeAreaPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var safeInsets = On<iOS>().SafeAreaInsets();
        //    safeInsets.Left = 20;
        //    Padding = safeInsets;
        //}

        void OnButtonClicked(object sender, EventArgs e)
        {
            On<iOS>().SetUseSafeArea(false);
            (sender as Button).IsEnabled = false;
        }
    }
}
