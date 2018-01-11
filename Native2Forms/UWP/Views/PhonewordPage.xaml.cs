using Phoneword.UWP.Models;
using Phoneword.UWP.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword.UWP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhonewordPage : ContentPage
    {
        string _translatedNumber;

        public PhonewordPage()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            _translatedNumber = PhonewordTranslatorService.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(_translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + _translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + _translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                var dialer = new PhoneDialerService();
                if (dialer != null)
                {
                    AppModel.PhoneNumbers.Add(_translatedNumber);
                    callHistoryButton.IsEnabled = true;
                    dialer.Dial(_translatedNumber);
                }
            }
        }

        void OnCallHistory(object sender, EventArgs e)
        {
            Phoneword.UWP.MainPage.Instance.NavigateToCallHistoryPage();
        }
    }
}
