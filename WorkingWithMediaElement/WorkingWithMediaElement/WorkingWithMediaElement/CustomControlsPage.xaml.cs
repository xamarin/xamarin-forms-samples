using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithMediaElement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomControlsPage : ContentPage
    {
        Timer _inactivityTimer;
        Timer _playbackTimer;

        public CustomControlsPage()
        {
            InitializeComponent();

            _inactivityTimer = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds);
            _inactivityTimer.Elapsed += _inactivityTimer_Elapsed;
            _inactivityTimer.Start();

            _playbackTimer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            _playbackTimer.Elapsed += _playbackTimer_Elapsed;
            _playbackTimer.Start();
        }

        private void _playbackTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.UpdateTimeDisplay();
        }

        private async void _inactivityTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await Task.WhenAny<bool>
            (
                PlayerHUD.FadeTo(0)
            );

            _inactivityTimer.Stop();
            _inactivityTimer.Start();

        }

        private void MediaElement_StateRequested(object sender, StateRequested e)
        {
            VisualStateManager.GoToState(PlayPauseToggle,
                (e.State == MediaElementState.Playing)
                ? "playing"
                : "paused");

            if (e.State == MediaElementState.Playing)
            {
                _playbackTimer.Stop();
                _playbackTimer.Start();

            }
            else if (e.State == MediaElementState.Paused || e.State == MediaElementState.Stopped)
            {
                _playbackTimer.Stop();
            }
        }

        private void PlayPauseToggle_Clicked(object sender, EventArgs e)
        {
            if (VideoPlayer.CurrentState == MediaElementState.Playing)
            {
                VideoPlayer.Pause();
            }
            else
            {
                VideoPlayer.Play();
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (PlayerHUD.Opacity == 1)
            {
                await Task.WhenAny<bool>
                (
                    PlayerHUD.FadeTo(0)
                );
            }
            else
            {
                await Task.WhenAny<bool>
                (
                    PlayerHUD.FadeTo(1, 100)
                );
            }

            _inactivityTimer.Stop();
            _inactivityTimer.Start();
        }

        private void VideoPlayer_MediaOpened(object sender, EventArgs e)
        {
            UpdateTimeDisplay();
        }

        private void UpdateTimeDisplay()
        {
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            {
                TimeAndDuration.Text = $"{VideoPlayer.Position.ToString(@"hh\:mm\:ss")} / {VideoPlayer.Duration?.ToString(@"hh\:mm\:ss")}";
            });
        }
    }
}