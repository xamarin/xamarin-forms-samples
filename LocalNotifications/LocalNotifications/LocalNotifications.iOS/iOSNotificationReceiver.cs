using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace LocalNotifications.iOS
{
    public class iOSNotificationReceiver : UNUserNotificationCenterDelegate
    {
        public iOSNotificationReceiver() { }

        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // let the scheduler know about the incoming notification
            var scheduler = ((App)App.Current).NotificationManager;
            scheduler.ReceiveNotification(notification.Request.Content.Title, notification.Request.Content.Body);

            // alerts are always shown for demonstration but this can be set to "None"
            // to avoid showing alerts if the app is in the foreground
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
    }
}