using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class ContentPageOneInNavigationPage : ContentPage
    {
        ICommand _returnToPlatformSpecificsPage;

        public ContentPageOneInNavigationPage(ICommand restore)
        {
            InitializeComponent();
            _returnToPlatformSpecificsPage = restore;
        }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPageTwo(_returnToPlatformSpecificsPage));
        }

        void OnReturnButtonClicked(object sender, EventArgs e)
        {
            _returnToPlatformSpecificsPage.Execute(null);
        }
    }
}
