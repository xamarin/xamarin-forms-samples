using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSModalFormSheetPage : ContentPage
    {
        public iOSModalFormSheetPage()
        {
            InitializeComponent();
        }

        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
