using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

namespace VisualDemos.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            FormsMaterial.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
