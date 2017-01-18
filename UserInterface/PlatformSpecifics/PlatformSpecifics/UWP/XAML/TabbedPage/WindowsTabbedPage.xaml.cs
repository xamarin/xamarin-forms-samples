using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class WindowsTabbedPage : TabbedPage
    {
        public WindowsTabbedPage()
        {
            InitializeComponent();
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
        }
    }
}
