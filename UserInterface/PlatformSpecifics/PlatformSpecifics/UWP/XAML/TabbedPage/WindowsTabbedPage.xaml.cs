using System;
using System.Windows.Input;

namespace PlatformSpecifics
{
    public partial class WindowsTabbedPage : Xamarin.Forms.TabbedPage
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
