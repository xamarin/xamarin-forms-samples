using System;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class CustomPositionBarPage : ContentPage
    {
        bool polling = true;

        public CustomPositionBarPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (mediaElement.CurrentState == MediaElementState.Playing)
                    {
                        positionLabel.Text = mediaElement.Position.ToString("hh\\:mm\\:ss");
                        positionSlider.Position = mediaElement.Position;
                    }
                });
                return polling;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            polling = false;
        }

        void OnPlayPauseButtonClicked(object sender, EventArgs args)
        {
            if (mediaElement.CurrentState == MediaElementState.Closed ||
                mediaElement.CurrentState == MediaElementState.Stopped ||
                mediaElement.CurrentState == MediaElementState.Paused)
            {
                mediaElement.Play();
            }
            else if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Pause();
            }
        }

        void OnStopButtonClicked(object sender, EventArgs args)
        {
            mediaElement.Stop();
            positionSlider.Value = 0;
        }

        void OnPositionSliderValueChanged(System.Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            polling = false;
            mediaElement.Position = positionSlider.Position;
            positionLabel.Text = mediaElement.Position.ToString("hh\\:mm\\:ss");
            polling = true;
        }
    }
}
