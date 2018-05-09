using CustomRenderer;
using CustomRenderer.UWP;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CameraPage), typeof(CameraPageRenderer))]
namespace CustomRenderer.UWP
{
    public class CameraPageRenderer : PageRenderer
    {
        // Rotation metadata to apply to preview stream (https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868174.aspx)
        static readonly Guid RotationKey = new Guid("C380465D-2271-428C-9B83-ECEA3B4A85C1"); // (MF_MT_VIDEO_ROTATION)

        MediaCapture _mediaCapture;
        CaptureElement _captureElement;
        StorageFolder _captureFolder = null;

        // Prevent the screen from sleeping while the camera is running
        DisplayRequest _displayRequest = new DisplayRequest();

        CameraRotationHelper _rotationHelper;

        Windows.UI.Xaml.Controls.Page _page;
        AppBarButton _takePhotoButton;
        Windows.UI.Xaml.Application _app;

        bool _isSuspending;
        bool _isInitialized;
        bool _isPreviewing;
        bool _isUIActive;
        bool _isActivePage;
        bool _mirroringPreview;
        bool _externalCamera;
        Task _setupTask = Task.CompletedTask;        

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                _app = Application.Current;
                _app.Suspending += OnAppSuspending;
                _app.Resuming += OnAppResuming;
                _isActivePage = true;

                SetupUserInterface();
                SetupBasedOnStateAsync();

                this.Children.Add(_page);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"      ERROR: ", ex.Message);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _page.Arrange(new Windows.Foundation.Rect(0, 0, finalSize.Width, finalSize.Height));
            return finalSize;
        }

        #region Event handlers

        async void OnTakePhotoButtonClicked(object sender, RoutedEventArgs e)
        {
            await TakePhotoAsync();
        }

        async void OnOrientationChanged(object sender, bool updatePreview)
        {
            if (updatePreview)
            {
                await SetPreviewRotationAsync();
            }
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => UpdateButtonOrientation());
        }

        #endregion

        #region Media capture

        async Task InitializeCameraAsync()
        {
            if (_mediaCapture == null)
            {
                // Attempt to get the back camera if one is available, but use any camera device if not
                var cameraDevice = await FindCameraDeviceByPanelAsync(Windows.Devices.Enumeration.Panel.Back);
                
                if (cameraDevice == null)
                {
                    Debug.WriteLine("No camera device found.");
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
                    Debug.WriteLine("The app was denied access to the camera.");
                }
                
                // If initialization succeeded, start the preview
                if (_isInitialized)
                {
                    // Figure out where the camera is located
                    if (cameraDevice.EnclosureLocation == null || cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Unknown)
                    {
                        // No information on the location of the camera, assume it's an external camera, not integrated on the device
                        _externalCamera = true;
                    }
                    else
                    {
                        // Camera is fixed on the device
                        _externalCamera = false;

                        // Only mirror the preview if the camera is on the front panel
                        _mirroringPreview = (cameraDevice.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
                    }
                    
                    _rotationHelper = new CameraRotationHelper(cameraDevice.EnclosureLocation);
                    _rotationHelper.OrientationChanged += OnOrientationChanged;
                    await StartPreviewAsync();
                }
            }
        }

        async Task StartPreviewAsync()
        {
            // Prevent the device from sleeping while the preview is running
            _displayRequest.RequestActive();

            // Set the preview source in the UI and mirror if necessary
            _captureElement.Source = _mediaCapture;
            _captureElement.FlowDirection = _mirroringPreview ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            // Start preview
            await _mediaCapture.StartPreviewAsync();
            _isPreviewing = true;

            // Initialize preview to current orientation
            await SetPreviewRotationAsync();
            _takePhotoButton.Click += OnTakePhotoButtonClicked;
        }

        async Task SetPreviewRotationAsync()
        {
            // Only update the orientation if the camera is mounted on the device
            if (_externalCamera)
                return;

            // Add rotation metadata to the preview stream to ensure aspect ratio/dimensions match when rendering and getting preview frames
            var orientation = _rotationHelper.GetCameraPreviewOrientation();
            var properties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview);
            properties.Properties.Add(RotationKey, CameraRotationHelper.ConvertSimpleOrientationToClockwiseDegrees(orientation));
            await _mediaCapture.SetEncodingPropertiesAsync(MediaStreamType.VideoPreview, properties, null);
        }

        async Task StopPreviewAsync()
        {
            _isPreviewing = false;
            await _mediaCapture.StopPreviewAsync();

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                _captureElement = null;

                // Allow the device screen to sleep now that the preview is stopped
                _displayRequest.RequestRelease();
            });
        }

        async Task TakePhotoAsync()
        {
            var stream = new InMemoryRandomAccessStream();
            await _mediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), stream);

            try
            {
                var file = await _captureFolder.CreateFileAsync("Photo.jpg", CreationCollisionOption.GenerateUniqueName);
                var orientation = CameraRotationHelper.ConvertSimpleOrientationToPhotoOrientation(_rotationHelper.GetCameraCaptureOrientation());
                await ReencodeAndSavePhotoAsync(stream, file, orientation);
                Debug.WriteLine("Photo saved to " + file.Path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception when taking photo: " + ex.ToString());
            }
        }

        async Task CleanupCameraAsync()
        {
            if (_isInitialized)
            {
                if (_isPreviewing)
                {
                    await StopPreviewAsync();
                }
                _isInitialized = false;
            }

            if (_mediaCapture != null)
            {
                _mediaCapture.Dispose();
                _mediaCapture = null;
            }
            if (_rotationHelper != null)
            {
                _rotationHelper.OrientationChanged -= OnOrientationChanged;
                _rotationHelper = null;
            }
        }

        #endregion

        #region Helpers

        void SetupUserInterface()
        {
            _takePhotoButton = new AppBarButton
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Icon = new SymbolIcon(Symbol.Camera),
                Label = "Take Photo"
            };

            var commandBar = new CommandBar();
            commandBar.PrimaryCommands.Add(_takePhotoButton);

            _captureElement = new CaptureElement();
            _captureElement.Stretch = Stretch.UniformToFill;

            var grid = new Grid();
            grid.Children.Add(_captureElement);

            _page = new Windows.UI.Xaml.Controls.Page();
            _page.BottomAppBar = commandBar;
            _page.Content = grid;
            _page.Unloaded += OnPageUnloaded;
        }

        void UpdateButtonOrientation()
        {
            // Rotate the UI app bar button to match the rotation of the device
            var angle = CameraRotationHelper.ConvertSimpleOrientationToClockwiseDegrees(_rotationHelper.GetUIOrientation());
            var transform = new RotateTransform { Angle = angle };

            _takePhotoButton.RenderTransform = transform;
        }

        async Task SetupBasedOnStateAsync()
        {
            while (!_setupTask.IsCompleted)
            {
                await _setupTask;
            }

            bool wantUIActive = _isActivePage && Window.Current.Visible && !_isSuspending;
            if (_isUIActive != wantUIActive)
            {
                _isUIActive = wantUIActive;
                Func<Task> setupAsync = async () =>
                {
                    if (wantUIActive)
                    {
                        await SetupUIAsync();
                        await InitializeCameraAsync();
                    }
                    else
                    {
                        await CleanupCameraAsync();
                        CleanupUIAsync();
                    }
                };
                _setupTask = setupAsync();
            }
            await _setupTask;
        }

        async Task SetupUIAsync()
        {
            // Lock page to landscape to prevent the CaptureElement rotating
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
            var picturesLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
            _captureFolder = picturesLibrary.SaveFolder ?? ApplicationData.Current.LocalFolder;
        }
 
        void CleanupUIAsync()
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }

        async Task<DeviceInformation> FindCameraDeviceByPanelAsync(Windows.Devices.Enumeration.Panel desiredPanel)
        {
            var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            var desiredDevice = allVideoDevices.FirstOrDefault(d => d.EnclosureLocation != null && d.EnclosureLocation.Panel == desiredPanel);
            return desiredDevice ?? allVideoDevices.FirstOrDefault();
        }

        static async Task ReencodeAndSavePhotoAsync(IRandomAccessStream stream, StorageFile file, PhotoOrientation orientation)
        {
            using (var inputStream = stream)
            {
                var decoder = await BitmapDecoder.CreateAsync(inputStream);
                using (var outputStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    var encoder = await BitmapEncoder.CreateForTranscodingAsync(outputStream, decoder);
                    var properties = new BitmapPropertySet { { "System.Photo.Orientation", new BitmapTypedValue(orientation, PropertyType.UInt16) } };
                    await encoder.BitmapProperties.SetPropertiesAsync(properties);
                    await encoder.FlushAsync();
                }
            }
        }

        #endregion

        #region Lifecycle

        async void OnAppSuspending(object sender, SuspendingEventArgs e)
        {
            _isSuspending = true;
            var deferral = e.SuspendingOperation.GetDeferral();
            await Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
            {
                await SetupBasedOnStateAsync();
                deferral.Complete();
            });
        }

        async void OnAppResuming(object sender, object o)
        {
            _isSuspending = false;
            await Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
            {
                await SetupBasedOnStateAsync();
            });
        }

        async void OnPageUnloaded(object sender, RoutedEventArgs e)
        {
            _app.Suspending -= OnAppSuspending;
            _app.Resuming -= OnAppResuming;
            _isActivePage = false;
            await SetupBasedOnStateAsync();
        }

        #endregion
    }
}
