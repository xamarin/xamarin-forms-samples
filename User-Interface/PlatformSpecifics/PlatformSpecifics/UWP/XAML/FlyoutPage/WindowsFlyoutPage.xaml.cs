using System;
using System.Windows.Input;

namespace PlatformSpecifics
{
    public partial class WindowsFlyoutPage : Xamarin.Forms.FlyoutPage
    {
        public WindowsFlyoutPage(ICommand restore)
        {
            InitializeComponent();
            Flyout = new ContentPageFlyoutPage(restore);
            Detail = new ContentPageDetailPage(restore);
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
        }
    }
}