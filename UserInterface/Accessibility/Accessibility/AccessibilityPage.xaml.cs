using System;
using Xamarin.Forms;

namespace Accessibility
{
    public partial class AccessibilityPage : ContentPage
    {
        public AccessibilityPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            activityIndicator.IsRunning = !activityIndicator.IsRunning;
            AutomationProperties.SetHelpText(activityIndicator, activityIndicator.IsRunning ? "Running" : "Not running");
        }

        async void OnImageTapped(object sender, EventArgs a)
        {
            await DisplayAlert("Success", "You tapped the image", "OK");
        }
    }
}
