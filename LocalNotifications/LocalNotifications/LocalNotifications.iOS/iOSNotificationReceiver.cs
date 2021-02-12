using System;
using UserNotifications;
using Xamarin.Forms;

namespace LocalNotifications.iOS
{
    public class iOSNotificationReceiver : UNUserNotificationCenterDelegate
    {
        // Called if app is in the foreground.
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            ProcessNotification(notification);
            completionHandler(UNNotificationPresentationOptions.Alert);
        }

        // Called if app is in the background, or killed state.
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            if (response.IsDefaultAction)
            {
                ProcessNotification(response.Notification);
            }
            completionHandler();
        }

        void ProcessNotification(UNNotification notification)
        {
            string title = notification.Request.Content.Title;
            string message = notification.Request.Content.Body;

            DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
        }
    }
}