using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSModalPagePresentationStyle : ContentPage
    {
        public iOSModalPagePresentationStyle()
        {
            InitializeComponent();
        }

        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
