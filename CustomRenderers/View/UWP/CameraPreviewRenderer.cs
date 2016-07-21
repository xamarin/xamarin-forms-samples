using CustomRenderer;
using CustomRenderer.UWP;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Devices.Enumeration;
using Windows.Devices.Sensors;
using Windows.Foundation.Metadata;
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
        readonly DisplayInformation displayInformation = DisplayInformation.GetForCurrentView();
        readonly SimpleOrientationSensor orientationSensor = SimpleOrientationSensor.GetDefault();
        readonly DisplayRequest displayRequest = new DisplayRequest();
        SimpleOrientation deviceOrientation = SimpleOrientation.NotRotated;
        DisplayOrientations displayOrientation = DisplayOrientations.Portrait;
        
        // Rotation metadata to apply to preview stream (https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868174.aspx)
        static readonly Guid RotationKey = new Guid("C380465D-2271-428C-9B83-ECEA3B4A85C1"); // (MF_MT_VIDEO_ROTATION)
        
        MediaCapture mediaCapture;
        CaptureElement captureElement;
        bool isInitialized;
        bool isPreviewing;
        bool externalCamera;
        bool mirroringPreview;

        Application app;
        CameraOptions cameraOptions;

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                app = Application.Current;
                app.Suspending += OnAppSuspending;
                app.Resuming += OnAppResuming;

                cameraOptions = e.NewElement.Camera;
                captureElement = new CaptureElement();
                captureElement.Stretch = Stretch.UniformToFill;

                SetupCamera();
                SetNativeControl(captureElement);
            }
            if (e.OldElement != null)
            {
                // Unsubscribe
                Tapped -= OnCameraPreviewTapped;
            }
            if (e.NewElement != null)
            {
                // Subscribe
                Tapped += OnCameraPreviewTapped;
            }
        }

        async void SetupCamera()
        {
            await SetupUIAsync();
            await InitializeCameraAsync();
        }

        #region Event Handlers

        async void OnCameraPreviewTapped(object sender, TappedRoutedEventArgs e)
        {
            if (isPreviewing)
            {
                await StopPreviewAsync();
            }
            else {
                await StartPreviewAsync();
            }
        }

        void OnOrientationSensorOrientationChanged(SimpleOrientationSensor sender, SimpleOrientationSensorOrientationChangedEventArgs args)
        {
            // Only update orientation if the device is not parallel to the ground
            if (args.Orientation != SimpleOrientation.Faceup && args.Orientation != SimpleOrientation.Facedown)
            {
                deviceOrientation = args.Orientation;
            }
        }

        async void OnDisplayInformationOrientationChanged(DisplayInformation sender, object args)
        {
            displayOrientation = sender.CurrentOrientation;

            if (isPreviewing)
            {
                await SetPreviewRotationAsync();
            }
        }

        #endregion

        #region Camera

        async Task InitializeCameraAsync()
        {
            if (mediaCapture == null)
            {
                DeviceInformation cameraDevice = null;
                var devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
                if (cameraOptions == CameraOptions.Rear)
                {
                    cameraDevice = devices.FirstOrDefault(c => c.EnclosureLocation != null && c.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back);
                }
                else
                {
                    cameraDevice = devices.FirstOrDefault(c => c.EnclosureLocation != null && c.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
                }
                
                if (cameraDevice == null)
                {
                    Debug.WriteLine("No camera found");
                    return;
                }

                mediaCapture = new MediaCapture();

                try
                {
                    await mediaCapture.InitializeAsync(new MediaCaptureInitializationSettings
                    {
                        VideoDeviceId = cameraDevice.Id,
                        AudioDeviceId = string.Empty,
                        StreamingCaptureMode = StreamingCaptureMode.Video,
                        PhotoCaptureSource = PhotoCaptureSource.Photo
                    });
                    isInitialized = true;
                }

                catch (UnauthorizedAccessException)
                {
                    Debug.WriteLine("Camera access denied");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception initializing MediaCapture - {0}: {1}", cameraDevice.Id, ex.ToString());
                }

                if (isInitialized)
                {
                    if (cameraDevice.EnclosureLocation == null || cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Unknown)
                    {
                        externalCamera = true;
                    }
                    else
                    {
                        // Camera is on device
                        externalCamera = false;

                        // Mirror preview if camera is on front panel
                        mirroringPreview = (cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
                    }
                    await StartPreviewAsync();
                }
            }
        }

        async Task StartPreviewAsync()
        {
            // Prevent the device from sleeping while the preview is running
            displayRequest.RequestActive();

            // Setup preview source in UI and mirror if required
            captureElement.Source = mediaCapture;
            captureElement.FlowDirection = mirroringPreview ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            // Start preview
            await mediaCapture.StartPreviewAsync();
            isPreviewing = true;

            if (isPreviewing)
            {
                await SetPreviewRotationAsync();
            }
        }

        async Task StopPreviewAsync()
        {
            isPreviewing = false;
            await mediaCapture.StopPreviewAsync();

            // Use dispatcher because sometimes this method is called from non-UI threads
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Allow device screen to sleep now preview is stopped
                displayRequest.RequestRelease();
            });
        }

        async Task SetPreviewRotationAsync()
        {
            // Only update the orientation if the camera is mounted on the device
            if (externalCamera)
            {
                return;
            }

            // Derive the preview rotation
            int rotation = ConvertDisplayOrientationToDegrees(displayOrientation);

            // Invert if mirroring
            if (mirroringPreview)
            {
                rotation = (360 - rotation) % 360;
            }

            // Add rotation metadata to preview stream
            var props = mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview);
            props.Properties.Add(RotationKey, rotation);
            await mediaCapture.SetEncodingPropertiesAsync(MediaStreamType.VideoPreview, props, null);
        }

        async Task CleanupCameraAsync()
        {
            if (isInitialized)
            {
                if (isPreviewing)
                {
                    await StopPreviewAsync();
                }
                isInitialized = false;
            }
            if (captureElement != null)
            {
                captureElement.Source = null;
            }
            if (mediaCapture != null)
            {
                mediaCapture.Dispose();
                mediaCapture = null;
            }
        }

        #endregion

        #region Helpers

        async Task SetupUIAsync()
        {
            // Lock page to landscape to prevent the capture element from rotating
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;

            // Hide status bar
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
            }

            displayOrientation = displayInformation.CurrentOrientation;
            if (orientationSensor != null)
            {
                deviceOrientation = orientationSensor.GetCurrentOrientation();
            }

            RegisterEventHandlers();
        }

        async Task CleanupUIAsync()
        {
            UnregisterEventHandlers();

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().ShowAsync();
            }

            // Revert orientation preferences
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }

        void RegisterEventHandlers()
        {
            if (orientationSensor != null)
            {
                orientationSensor.OrientationChanged += OnOrientationSensorOrientationChanged;
            }

            displayInformation.OrientationChanged += OnDisplayInformationOrientationChanged;
        }

        void UnregisterEventHandlers()
        {
            if (orientationSensor != null)
            {
                orientationSensor.OrientationChanged -= OnOrientationSensorOrientationChanged;
            }

            displayInformation.OrientationChanged -= OnDisplayInformationOrientationChanged;
        }

        static int ConvertDisplayOrientationToDegrees(DisplayOrientations orientation)
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
            await CleanupUIAsync();
            deferral.Complete();
        }

        async void OnAppResuming(object sender, object o)
        {
            await SetupUIAsync();
            await InitializeCameraAsync();
        }

        #endregion
    }
}
