using CustomRenderer;
using CustomRenderer.WinPhone81;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer (typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace CustomRenderer.WinPhone81
{
	public class CameraPreviewRenderer : ViewRenderer<CameraPreview, Windows.UI.Xaml.Controls.CaptureElement>
	{
		MediaCapture mediaCapture;
		CaptureElement captureElement;
		CameraOptions cameraOptions;
		Application app;
		bool isPreviewing = false;

		protected override void OnElementChanged (ElementChangedEventArgs<CustomRenderer.CameraPreview> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				app = Application.Current;
				app.Suspending += OnAppSuspending;
				app.Resuming += OnAppResuming;
				HardwareButtons.BackPressed += OnBackButtonPressed;

                cameraOptions = e.NewElement.Camera;
				captureElement = new CaptureElement ();
				captureElement.Stretch = Stretch.UniformToFill;

				InitializeAsync ();
				SetNativeControl (captureElement);
			}
			if (e.OldElement != null) {
				// Unsubscribe
				Tapped -= OnCameraPreviewTapped;
			}
			if (e.NewElement != null) {
				// Subscribe
				Tapped += OnCameraPreviewTapped;
			}
		}

		async void OnCameraPreviewTapped (object sender, TappedRoutedEventArgs e)
		{
			if (isPreviewing) {
				await mediaCapture.StopPreviewAsync ();
				isPreviewing = false;
			} else {
				await mediaCapture.StartPreviewAsync ();
				isPreviewing = true;
			}
		}

		async void InitializeAsync ()
		{
			DeviceInformation camera = null;

			try {
				var devices = await DeviceInformation.FindAllAsync (DeviceClass.VideoCapture);
				if (cameraOptions == CameraOptions.Rear) {
					camera = devices.FirstOrDefault (c => c.EnclosureLocation != null && c.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back);
				} else {
					camera = devices.FirstOrDefault (c => c.EnclosureLocation != null && c.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
				}

				mediaCapture = new MediaCapture ();
				await mediaCapture.InitializeAsync (new MediaCaptureInitializationSettings {
					VideoDeviceId = camera.Id,
					AudioDeviceId = string.Empty,
					StreamingCaptureMode = StreamingCaptureMode.Video,
					PhotoCaptureSource = PhotoCaptureSource.VideoPreview
				});

				captureElement.Source = mediaCapture;
				await mediaCapture.StartPreviewAsync ();
				isPreviewing = true;
			} catch (Exception ex) {
				Debug.WriteLine (@"      ERROR: ", ex.Message);
			}
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
			InitializeAsync ();
		}

		void OnPageUnloaded (object sender, RoutedEventArgs e)
		{
			HardwareButtons.BackPressed -= OnBackButtonPressed;
		}

		async Task CleanUpCaptureResourcesAsync ()
		{
			if (isPreviewing && mediaCapture != null) {
				try {
					await mediaCapture.StopPreviewAsync ();
					isPreviewing = false;
				} catch (Exception ex) {
					Debug.WriteLine (@"      ERROR: ", ex.Message);
				}
			}

			if (mediaCapture != null) {
				if (captureElement != null) {
					captureElement.Source = null;
				}

				try {
					mediaCapture.Dispose ();
				} catch (Exception ex) {
					Debug.WriteLine (@"      ERROR: ", ex.Message);
				}
			}
		}
	}
}
