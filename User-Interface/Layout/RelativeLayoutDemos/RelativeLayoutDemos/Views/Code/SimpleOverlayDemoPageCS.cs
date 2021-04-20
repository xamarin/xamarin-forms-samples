using System;
using Xamarin.Forms;

namespace RelativeLayoutDemos.Views
{
    public class SimpleOverlayDemoPageCS : ContentPage
    {
        ContentView overlay;
        ProgressBar progressBar;

        public SimpleOverlayDemoPageCS()
        {
            Button button = new Button { Text = "Simulate 5-second work item" };
            button.Clicked += OnButtonClicked;

            StackLayout stackLayout = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Label { Text = "This might be a page of UI objects except that the only functional UI object on the page is a Button." },
                    button
                }
            };

            progressBar = new ProgressBar
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.Center
            };

            overlay = new ContentView
            {
                BackgroundColor = Color.FromHex("#C0808080"),
                IsVisible = false,
                Content = progressBar
            };

            RelativeLayout relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(stackLayout, () => 0, () => 0);
            relativeLayout.Children.Add(overlay, () => new Rectangle(0, 0, relativeLayout.Width, relativeLayout.Height));

            Title = "Simple overlay demo";
            Content = relativeLayout;
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
