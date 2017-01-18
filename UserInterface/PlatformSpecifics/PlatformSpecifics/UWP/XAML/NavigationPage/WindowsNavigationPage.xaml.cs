using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class WindowsNavigationPage : NavigationPage
    {
        public WindowsNavigationPage()
        {
            InitializeComponent();
            PushAsync(new ContentPageOneInNavigationPage());
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
        }
    }
}
