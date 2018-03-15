using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace HelloXamarinFormsWorld.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
        }
    }
}
