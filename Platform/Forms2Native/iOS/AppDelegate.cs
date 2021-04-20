using Foundation;
using UIKit;

namespace SimpleColorPicker.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

            // HACK: Stop the linker removing the below types for device builds
            var color = UIColor.Red;
            color = UIColor.Green;
            color = UIColor.Blue;
            color = UIColor.Black;

            return base.FinishedLaunching(app, options);
		}
	}
}
