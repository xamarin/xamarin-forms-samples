using System;
using Xamarin.Forms;

namespace SystemThemesDemo.Views
{
    public partial class UserSummaryPage : ContentPage
    {
        public UserSummaryPage()
        {
            InitializeComponent();
        }

        async void OnNavigationInvoked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserDetailsPage());
        }
    }
}
