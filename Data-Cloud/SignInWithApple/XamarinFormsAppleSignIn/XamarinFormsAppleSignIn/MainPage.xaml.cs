using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsAppleSignIn.Services;

namespace XamarinFormsAppleSignIn
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SignIn_Event(object sender, EventArgs e)
        {
            var appleSignIn = Xamarin.Forms.DependencyService.Get<IAppleSignInService>();

            var account = await appleSignIn.SignInAsync();

            labelText.Text = $"Signed in!\n  Name: {account.Name}\n  Email: {account.Email}\n  UserId: {account.UserId}";
        }
    }
}
