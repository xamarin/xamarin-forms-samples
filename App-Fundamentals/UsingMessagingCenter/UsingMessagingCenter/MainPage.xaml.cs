using System;
using Xamarin.Forms;

namespace UsingMessagingCenter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            // Subscribe to a message (which the ViewModel has also subscribed to) to display an alert
            MessagingCenter.Subscribe<MainPage, string>(this, "Hi", async (sender, arg) =>
            {
                await DisplayAlert("Message received", "arg=" + arg, "OK");
            });
        }

        void OnSayHiButtonClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<MainPage>(this, "Hi");
        }

        void OnSayHiToJohnButtonClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<MainPage, string>(this, "Hi", "John");
        }

        async void OnUnsubscribeButtonClicked(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<MainPage, string>(this, "Hi");
            await DisplayAlert("Unsubscribed", "This page has stopped listening, so no more alerts. However, the ViewModel is still receiving messages.", "OK");
        }
    }
}
