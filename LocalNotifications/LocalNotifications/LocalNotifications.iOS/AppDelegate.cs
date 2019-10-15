using Foundation;
using UIKit;
using UserNotifications;

namespace LocalNotifications.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // set a delegate to handle incoming notifications
            UNUserNotificationCenter.Current.Delegate = new iOSNotificationReceiver();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
