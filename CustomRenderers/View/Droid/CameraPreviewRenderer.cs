using System;
using Android.Hardware;
using CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(CustomRenderer.CameraPreview), typeof(CameraPreviewRenderer))]
namespace CustomRenderer.Droid
{
	public class CameraPreviewRenderer : ViewRenderer<CustomRenderer.CameraPreview, CustomRenderer.Droid.CameraPreview>
	{
		CameraPreview cameraPreview;

		protected override void OnElementChanged (ElementChangedEventArgs<CustomRenderer.CameraPreview> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				cameraPreview = new CameraPreview (Context);
				SetNativeControl (cameraPreview);
			}

			if (e.OldElement != null) {
				// Unsubscribe
				cameraPreview.Click -= OnCameraPreviewClicked;
			}
			if (e.NewElement != null) {
				Control.Preview = Camera.Open ((int)e.NewElement.Camera);

				// Subscribe
				cameraPreview.Click += OnCameraPreviewClicked;
			}
		}

		void OnCameraPreviewClicked (object sender, EventArgs e)
		{
			if (cameraPreview.IsPreviewing) {
				cameraPreview.Preview.StopPreview ();
				cameraPreview.IsPreviewing = false;
			} else {
				cameraPreview.Preview.StartPreview ();
				cameraPreview.IsPreviewing = true;
			}
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing) {
				Control.Preview.Release ();
			}
			base.Dispose (disposing);
		}
	}
}
