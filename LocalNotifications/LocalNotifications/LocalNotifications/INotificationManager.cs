using System;
using System.Collections.Generic;
using System.Text;

namespace LocalNotifications
{
    public interface INotificationManager
    {
        // allows UI to respond to incoming notifications
        event EventHandler NotificationReceived;

        // allows platform implementations to perform startup tasks
        void Initialize();

        // provides cross-platform way of scheduling a notification
        int ScheduleNotification(string title, string message);

        // provides cross-platform way of receiving notification
        void ReceiveNotification(string title, string message);
    }
}
