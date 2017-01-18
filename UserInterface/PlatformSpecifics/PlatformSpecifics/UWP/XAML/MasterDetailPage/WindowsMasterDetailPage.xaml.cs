using System;

namespace PlatformSpecifics
{
    public partial class WindowsMasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        public WindowsMasterDetailPage()
        {
            InitializeComponent();
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
        }
    }
}