using CustomRenderer;
using CustomRenderer.UWP;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Devices.Enumeration;
using Windows.Graphics.Display;
using Windows.Media.Capture;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace CustomRenderer.UWP
{
    public class CameraPreviewRenderer : ViewRenderer<CameraPreview, Windows.UI.Xaml.Controls.CaptureElement>
    {
        readonly DisplayInformation _displayInformation = DisplayInformation.GetForCurrentView();
        DisplayOrientations _displayOrientation = DisplayOrientations.Portrait;
        readonly DisplayRequest _displayRequest = new DisplayRequest();
        
        // Rotation metadata to apply to preview stream (https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868174.aspx)
        static readonly Guid RotationKey = new Guid("C380465D-2271-428C-9B83-ECEA3B4A85C1"); // (MF_MT_VIDEO_ROTATION)

        static readonly SemaphoreSlim _mediaCaptureLifeLock = new SemaphoreSlim(1);

        MediaCapture _mediaCapture;
        CaptureElement _captureElement;
        bool _isInitialized;
        bool _isPreviewing;
        bool _externalCamera;
        bool _mirroringPreview;

        Application _app;

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
                Tapped -= OnCameraPreviewTapped;
                _displayInformation.OrientationChanged -= OnOrientationChanged;
                _app.Suspending -= OnAppSuspending;
                _app.Resuming -= OnAppResuming;
            }
            if (e.NewElement != null)
            {
				if (Control == null)
				{
					_app = Application.Current;
					_app.Suspending += OnAppSuspending;
					_app.Resuming += OnAppResuming;

					_captureElement = new CaptureElement();
					_captureElement.Stretch = Stretch.UniformToFill;

					SetupCamera();
					SetNativeControl(_captureElement);
				}

				// Subscribe
				Tapped += OnCameraPreviewTapped;
            }
        }

        async void SetupCamera()
        {
            _displayOrientation = _displayInformation.CurrentOrientation;
            _displayInformation.OrientationChanged += OnOrientationChanged;
            await InitializeCameraAsync();
        }

        #region Event Handlers

        async void OnOrientationChanged(DisplayInformation sender, object args)
        {
            _displayOrientation = sender.CurrentOrientation;
            if (_isPreviewing)
            {
                await SetPreviewRotationAsync();
            }
        }

        async void OnCameraPreviewTapped(object sender, TappedRoutedEventArgs e)
        {
            if (_isPreviewing)
            {
                await StopPreviewAsync();
            }
            else
            {
                await StartPreviewAsync();
            }
        }

        #endregion

        #region Camera

        async Task InitializeCameraAsync()
        {
            await _mediaCaptureLifeLock.WaitAsync();

            if (_mediaCapture == null)
            {
                // Attempt to get the back camera, but use any camera if not
                var cameraDevice = await FindCameraDeviceByPanelAsync(Windows.Devices.Enumeration.Panel.Back);
                if (cameraDevice == null)
                {
                    Debug.WriteLine("No camera found");
                    return;
                }

                _mediaCapture = new MediaCapture();
                var settings = new MediaCaptureInitializationSettings { VideoDeviceId = cameraDevice.Id };
                try
                {
                    await _mediaCapture.InitializeAsync(settings);
                    _isInitialized = true;
                }

                catch (UnauthorizedAccessException)
                {
                    Debug.WriteLine("Camera access denied");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception initializing MediaCapture - {0}: {1}", cameraDevice.Id, ex.ToString());
                }
                finally
                {
                    _mediaCaptureLifeLock.Release();
                }

                if (_isInitialized)
                {
                    if (cameraDevice.EnclosureLocation == null || cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Unknown)
                    {
                        _externalCamera = true;
                    }
                    else
                    {
                        // Camera is on device
                        _externalCamera = false;

                        // Mirror preview if camera is on front panel
                        _mirroringPreview = (cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
                    }
                    await StartPreviewAsync();
                }
            }
            else
            {
                _mediaCaptureLifeLock.Release();
            }
        }

        async Task StartPreviewAsync()
        {
            // Prevent the device from sleeping while the preview is running
            _displayRequest.RequestActive();

            // Setup preview source in UI and mirror if required
            _captureElement.Source = _mediaCapture;
            _captureElement.FlowDirection = _mirroringPreview ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            // Start preview
            await _mediaCapture.StartPreviewAsync();
            _isPreviewing = true;

            if (_isPreviewing)
            {
                await SetPreviewRotationAsync();
            }
        }

        async Task StopPreviewAsync()
        {
            _isPreviewing = false;
            await _mediaCapture.StopPreviewAsync();

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Allow device screen to sleep now preview is stopped
                _displayRequest.RequestRelease();
            });
        }

        async Task SetPreviewRotationAsync()
        {
            // Only update the orientation if the camera is mounted on the device
            if (_externalCamera)
            {
                return;
            }

            // Derive the preview rotation
            int rotation = ConvertDisplayOrientationToDegrees(_displayOrientation);

            // Invert if mirroring
            if (_mirroringPreview)
            {
                rotation = (360 - rotation) % 360;
            }

            // Add rotation metadata to preview stream
            var props = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview);
            props.Properties.Add(RotationKey, rotation);
            await _mediaCapture.SetEncodingPropertiesAsync(MediaStreamType.VideoPreview, props, null);
        }

        async Task CleanupCameraAsync()
        {
            await _mediaCaptureLifeLock.WaitAsync();

            if (_isInitialized)
            {
                if (_isPreviewing)
                {
                    await StopPreviewAsync();
                }
                _isInitialized = false;
            }
            if (_captureElement != null)
            {
                _captureElement.Source = null;
            }
            if (_mediaCapture != null)
            {
                _mediaCapture.Dispose();
                _mediaCapture = null;
            }
        }

        #endregion

        #region Helpers

        async Task<DeviceInformation> FindCameraDeviceByPanelAsync(Windows.Devices.Enumeration.Panel desiredPanel)
        {

            var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            var desiredDevice = allVideoDevices.FirstOrDefault(d => d.EnclosureLocation != null && d.EnclosureLocation.Panel == desiredPanel);
            return desiredDevice ?? allVideoDevices.FirstOrDefault();
        }

        int ConvertDisplayOrientationToDegrees(DisplayOrientations orientation)
        {
            switch (orientation)
            {
                case DisplayOrientations.Portrait:
                    return 90;
                case DisplayOrientations.LandscapeFlipped:
                    return 180;
                case DisplayOrientations.PortraitFlipped:
                    return 270;
                case DisplayOrientations.Landscape:
                default:
                    return 0;
            }
        }

        #endregion

        #region Lifecycle

        async void OnAppSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await CleanupCameraAsync();
            _displayInformation.OrientationChanged -= OnOrientationChanged;
            deferral.Complete();
        }

        void OnAppResuming(object sender, object o)
        {
            _displayOrientation = _displayInformation.CurrentOrientation;
            _displayInformation.OrientationChanged += OnOrientationChanged;
        }

        #endregion
    }
}
