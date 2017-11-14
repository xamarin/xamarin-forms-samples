using System;
using System.Windows.Input;

namespace PlatformSpecifics
{
    public partial class WindowsMasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        public WindowsMasterDetailPage(ICommand restore)
        {
            InitializeComponent();
            Master = new ContentPageMasterPage(restore);
            Detail = new ContentPageDetailPage(restore);
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
        }
    }
}