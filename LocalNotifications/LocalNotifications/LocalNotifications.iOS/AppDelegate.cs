using System;
using System.Collections.Generic;
using System.Linq;

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

            // initialize the forms app with a platform-specific notification manager
            var iosNotificationManager = new iOSNotificationManager();
            var formsApp = new App(iosNotificationManager);

            // set a delegate to handle incoming notifications
            UNUserNotificationCenter.Current.Delegate = new iOSNotificationReceiver();

            LoadApplication(formsApp);

            return base.FinishedLaunching(app, options);
        }
    }
}
