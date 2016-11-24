using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class ContentPageOneInNavigationPage : ContentPage
    {
        public ContentPageOneInNavigationPage()
        {
            InitializeComponent();
        }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPageTwo());
        }
    }
}
