using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class ProgressBarDemoPage : ContentPage
    {
        ProgressBar progressBar;
        bool isActiveWindow;

        public ProgressBarDemoPage()
        {
            Label header = new Label
            {
                Text = "ProgressBar",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            progressBar = new ProgressBar
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    progressBar
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isActiveWindow = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.1), TimerCallback);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isActiveWindow = false;
        }

        bool TimerCallback()
        {
            progressBar.Progress += 0.01; 
            return isActiveWindow || progressBar.Progress == 1;
        }
    }
}
