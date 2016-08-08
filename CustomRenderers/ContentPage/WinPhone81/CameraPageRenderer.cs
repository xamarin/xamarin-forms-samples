using CustomRenderer;
using CustomRenderer.WinPhone81;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(CameraPage), typeof(CameraPageRenderer))]
namespace CustomRenderer.WinPhone81
{
    public class CameraPageRenderer : PageRenderer
	{
		Page page;
		MediaCapture mediaCapture;
		CaptureElement captureElement;
		AppBarButton takePhotoButton;
		Application app;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null || Element == null) {
				return;
			}

			try {
				app = Application.Current;
				app.Suspending += OnAppSuspending;
				app.Resuming += OnAppResuming;

				HardwareButtons.BackPressed += OnBackButtonPressed;

				SetupUserInterface ();
				SetupEventHandlers ();
				SetupLiveCameraStream ();

                this.Children.Add(page);
			} catch (Exception ex) {
				Debug.WriteLine (@"      ERROR: ", ex.Message);
			}
		}

        protected override Windows.Foundation.Size ArrangeOverride(Windows.Foundation.Size finalSize)
        {
            page.Arrange(new Windows.Foundation.Rect(0, 0, finalSize.Width, finalSize.Height));
            return finalSize;
        }

		void SetupUserInterface ()
		{
			takePhotoButton = new AppBarButton {
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center,
				Icon = new SymbolIcon (Symbol.Camera)
			};

			var commandBar = new CommandBar ();
			commandBar.PrimaryCommands.Add (takePhotoButton);

			captureElement = new CaptureElement ();
            captureElement.Stretch = Stretch.UniformToFill;
                       
			var stackPanel = new StackPanel ();
			stackPanel.Children.Add (captureElement);

			page = new Page ();
			page.BottomAppBar = commandBar;
			page.Content = stackPanel;
			page.Unloaded += OnPageUnloaded;
		}

		void SetupEventHandlers ()
		{
			takePhotoButton.Click += (object sender, RoutedEventArgs e) => {
				CapturePhoto ();
			};
		}

		async void SetupLiveCameraStream ()
		{
			var devices = await DeviceInformation.FindAllAsync (DeviceClass.VideoCapture);
			//var frontCamera = devices.FirstOrDefault(c => c.EnclosureLocation != null && c.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
			var backCamera = devices.FirstOrDefault (c => c.EnclosureLocation != null && c.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back);

			mediaCapture = new MediaCapture ();
			await mediaCapture.InitializeAsync (new MediaCaptureInitializationSettings {
				VideoDeviceId = backCamera.Id,
				AudioDeviceId = string.Empty,
				StreamingCaptureMode = StreamingCaptureMode.Video,
				PhotoCaptureSource = PhotoCaptureSource.Photo
			});

			captureElement.Source = mediaCapture;
            await mediaCapture.StartPreviewAsync ();
		}

		async void CapturePhoto ()
		{
			var photoFolder = KnownFolders.CameraRoll;
			var photoFile = await photoFolder.CreateFileAsync ("photo.jpg", CreationCollisionOption.GenerateUniqueName);
			var photoEncoding = ImageEncodingProperties.CreateJpeg ();
			await mediaCapture.CapturePhotoToStorageFileAsync (photoEncoding, photoFile);
		}

		async void OnBackButtonPressed (object sender, BackPressedEventArgs e)
		{
			await CleanUpCaptureResourcesAsync ();
		}

		async void OnAppSuspending (object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral ();
			await CleanUpCaptureResourcesAsync ();
			deferral.Complete ();
		}

		void OnAppResuming (object sender, object e)
		{
			SetupLiveCameraStream ();
		}

		void OnPageUnloaded (object sender, RoutedEventArgs e)
		{
			HardwareButtons.BackPressed -= OnBackButtonPressed;
		}

		async Task CleanUpCaptureResourcesAsync ()
		{
			if (captureElement != null) {
				captureElement.Source = null;
			}

			if (mediaCapture != null) {
				try {
					await mediaCapture.StopPreviewAsync ();
				} catch (Exception ex) {
					Debug.WriteLine (@"          Error: ", ex.Message);
				}
			}

			if (mediaCapture != null) {
				try {
					mediaCapture.Dispose ();
				} catch (Exception ex) {
					Debug.WriteLine (@"          Error: ", ex.Message);
				}
			}
		}
	}
}

