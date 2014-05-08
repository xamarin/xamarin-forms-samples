using System;
using Xamarin.Forms;
using MonoTouch.UIKit;
using Notifications.Core;

namespace Notifications
{
	public class ApplePushNotificationProxy : IPushNotificationProxy
    {
		public static ApplePushNotificationProxy Default { get; private set; }

		static void OnNotificationRequest(Page sender, PushNotification args)
		{
			var notification = new UILocalNotification ();

			//---- set the fire date (the date time in which it will fire)
			notification.FireDate = DateTime.Now.AddSeconds (15);

			//---- configure the alert stuff
			notification.AlertAction = "View Alert";
			notification.AlertBody = args.Title;

			//---- modify the badge
			notification.ApplicationIconBadgeNumber = 1;

			//---- set the sound to be the default sound
			notification.SoundName = UILocalNotification.DefaultSoundName;

			//---- schedule it
			UIApplication.SharedApplication.ScheduleLocalNotification (notification);
		}

		static ApplePushNotificationProxy ()
        {
			Default = new ApplePushNotificationProxy();

			MessagingCenter.Subscribe<Page,PushNotification>(Default, PushNotification.Subject, OnNotificationRequest);
        }
    }
}

