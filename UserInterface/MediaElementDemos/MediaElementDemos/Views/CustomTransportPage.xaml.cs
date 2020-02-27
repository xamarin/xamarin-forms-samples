using System;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class CustomTransportPage : ContentPage
    {
        public CustomTransportPage()
        {
            InitializeComponent();
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
        }
    }
}
