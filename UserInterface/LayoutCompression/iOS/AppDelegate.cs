using Foundation;
using UIKit;
using ImageCircle.Forms.Plugin.iOS;

namespace LayoutCompression.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
