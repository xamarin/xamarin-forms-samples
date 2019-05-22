using Foundation;
using Microsoft.Identity.Client;
using UIKit;

namespace ADB2CAuthorization.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            var result = base.FinishedLaunching(app, options);
            App.AuthenticationClient.iOSKeychainSecurityGroup = "com.xamarin.adb2cauthorization";
            return result;
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
            return base.OpenUrl(app, url, options);
        }
    }
}

