using System;
using Xamarin.Forms;

using XamarinFormsSample.Model;

namespace XamarinFormsXamlSample
{
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LogMeIn(object sender, EventArgs args)
        {
            App.IsLoggedIn = (this.Resources["credentials"] as LoginInfo).CanLogin;
            await Navigation.PopAsync();
        }
    }
}
