using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BiometricAuthDemo
{
    public partial class MainPage : ContentPage
    {
        IBiometricAuthProvider authProvider;

        public MainPage()
        {
            InitializeComponent();

            authProvider = DependencyService.Get<IBiometricAuthProvider>();
        }

        void OnAuthButtonClicked(object sender, EventArgs e)
        {
            if(authProvider.IsBiometricAuthEnabled)
            {
                authProvider.RequestAuthentication((result) =>
                {
                    UpdateResultText(result.Success, result.Message);
                });
            }
            else
            {
                UpdateResultText(false, "Biometric authentication is not enabled on this device.");
            }
        }

        void UpdateResultText(bool success, string message)
        {
            authResultMessage.TextColor = success ? Color.Green : Color.Red;
            authResultMessage.Text = message;
        }
    }
}
