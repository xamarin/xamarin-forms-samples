using System;
using System.ComponentModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using WinControls = Windows.UI.Xaml.Controls;
using WinMedia = Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using FactoriesDemo;

[assembly: ExportRenderer(typeof(FormsVideoLibrary.VideoPlayer),
                          typeof(FormsVideoLibrary.UWP.VideoPlayerRenderer))]
namespace FormsVideoLibrary.UWP
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, WinControls.MediaElement>
    {
        ILogger _logger;

        public VideoPlayerRenderer(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            _logger.Log("OnElementChanged invoked.");

            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    WinControls.MediaElement mediaElement = new WinControls.MediaElement();
                    SetNativeControl(mediaElement);

                    mediaElement.MediaOpened += OnMediaElementMediaOpened;
                    mediaElement.CurrentStateChanged += OnMediaElementCurrentStateChanged;
                }

                SetAreTransportControlsEnabled();
                SetSource();
                SetAutoPlay();

                args.NewElement.UpdateStatus += OnUpdateStatus;
                args.NewElement.PlayRequested += OnPlayRequested;
                args.NewElement.PauseRequested += OnPauseRequested;
                args.NewElement.StopRequested += OnStopRequested;
            }

            if (args.OldElement != null)
            {
                args.OldElement.UpdateStatus -= OnUpdateStatus;
                args.OldElement.PlayRequested -= OnPlayRequested;
                args.OldElement.PauseRequested -= OnPauseRequested;
                args.OldElement.StopRequested -= OnStopRequested;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _logger.Log("Dispose invoked");

            if (Control != null)
            {
                Control.MediaOpened -= OnMediaElementMediaOpened;
                Control.CurrentStateChanged -= OnMediaElementCurrentStateChanged;
            }

            base.Dispose(disposing);
        }

        void OnMediaElementMediaOpened(object sender, RoutedEventArgs args)
        {
            _logger.Log("OnMediaElementMediaOpened invoked");

            ((IVideoPlayerController)Element).Duration = Control.NaturalDuration.TimeSpan;
        }

        void OnMediaElementCurrentStateChanged(object sender, RoutedEventArgs args)
        {
            _logger.Log("OnMediaElementCurrentStateChanged invoked.");

            VideoStatus videoStatus = VideoStatus.NotReady;

            switch (Control.CurrentState)
            {
                case WinMedia.MediaElementState.Playing:
                    videoStatus = VideoStatus.Playing;
                    break;

                case WinMedia.MediaElementState.Paused:
                case WinMedia.MediaElementState.Stopped:
                    videoStatus = VideoStatus.Paused;
                    break;
            }

            ((IVideoPlayerController)Element).Status = videoStatus;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            _logger.Log("OnElementPropertyChanged invoked.");

            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.AreTransportControlsEnabledProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
            else if (args.PropertyName == VideoPlayer.AutoPlayProperty.PropertyName)
            {
                SetAutoPlay();
            }
            else if (args.PropertyName == VideoPlayer.PositionProperty.PropertyName)
            {
                if (Math.Abs((Control.Position - Element.Position).TotalSeconds) > 1)
                {
                    Control.Position = Element.Position;
                }
            }
        }

        void SetAreTransportControlsEnabled()
        {
            _logger.Log("SetAreTransportControlsEnabled invoked.");

            Control.AreTransportControlsEnabled = Element.AreTransportControlsEnabled;
        }

        async void SetSource()
        {
            _logger.Log("SetSource invoked.");

            bool hasSetSource = false;

            if (Element.Source is UriVideoSource)
            {
                string uri = (Element.Source as UriVideoSource).Uri;

                if (!String.IsNullOrWhiteSpace(uri))
                {
                    Control.Source = new Uri(uri);
                    hasSetSource = true;
                }
            }
            else if (Element.Source is FileVideoSource)
            {
                // Code requires Pictures Library in Package.appxmanifest Capabilities to be enabled
                string filename = (Element.Source as FileVideoSource).File;

                if (!String.IsNullOrWhiteSpace(filename))
                {
                    StorageFile storageFile = await StorageFile.GetFileFromPathAsync(filename);
                    IRandomAccessStreamWithContentType stream = await storageFile.OpenReadAsync();
                    Control.SetSource(stream, storageFile.ContentType);
                    hasSetSource = true;
                }
            }
            else if (Element.Source is ResourceVideoSource)
            {
                string path = "ms-appx:///" + (Element.Source as ResourceVideoSource).Path;

                if (!String.IsNullOrWhiteSpace(path))
                {
                    Control.Source = new Uri(path);
                    hasSetSource = true;
                }
            }

            if (!hasSetSource)
            {
                Control.Source = null;
            }
        }

        void SetAutoPlay()
        {
            _logger.Log("SetAutoPlay invoked.");

            Control.AutoPlay = Element.AutoPlay;
        }

        // Event handler to update status
        void OnUpdateStatus(object sender, EventArgs args)
        {
            _logger.Log("OnUpdateStatus invoked.");

            ((IElementController)Element).SetValueFromRenderer(VideoPlayer.PositionProperty, Control.Position);
        }

        // Event handlers to implement methods
        void OnPlayRequested(object sender, EventArgs args)
        {
            _logger.Log("OnPlayRequested invoked.");

            Control.Play();
        }

        void OnPauseRequested(object sender, EventArgs args)
        {
            _logger.Log("OnPauseRequested invoked.");

            Control.Pause();
        }

        void OnStopRequested(object sender, EventArgs args)
        {
            _logger.Log("OnStopRequested invoked.");

            Control.Stop();
        }
    }
}