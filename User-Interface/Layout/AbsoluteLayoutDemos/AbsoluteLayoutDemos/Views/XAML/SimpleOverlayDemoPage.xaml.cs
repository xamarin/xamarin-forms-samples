using System;
using Xamarin.Forms;

namespace AbsoluteLayoutDemos.Views
{
    public partial class SimpleOverlayDemoPage : ContentPage
    {
        public SimpleOverlayDemoPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            // Show overlay with ProgressBar
            overlay.IsVisible = true;

            TimeSpan duration = TimeSpan.FromSeconds(5);
            DateTime now = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                double progress = (DateTime.Now - now).TotalMilliseconds / duration.TotalMilliseconds;
                progressBar.Progress = progress;
                bool continueTimer = progress < 1;

                if (!continueTimer)
                {
                    overlay.IsVisible = false;
                }
                return continueTimer;
            });
        }
    }
}
