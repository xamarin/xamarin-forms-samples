using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class WindowsTabbedPage : TabbedPage
    {
        public WindowsTabbedPage(ICommand restore)
        {
            InitializeComponent();
            Children.Add(new ContentPageOneInTabbedPage(restore));
            Children.Add(new ContentPageTwo(restore));
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
        }
    }
}
