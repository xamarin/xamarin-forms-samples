using Xamarin.Forms;

namespace CustomRenderer
{
	public class CameraPreview : View
	{
		public static readonly BindableProperty CameraProperty = BindableProperty.Create ("CameraOptions", typeof(CameraOptions), typeof(CameraPreview), CameraOptions.Rear);

		public CameraOptions Camera {
			get { return (CameraOptions)GetValue (CameraProperty); }
			set { SetValue (CameraProperty, value); }
		}
	}
}
