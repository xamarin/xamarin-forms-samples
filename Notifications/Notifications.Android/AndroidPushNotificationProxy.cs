using System;
using Xamarin.Forms;
using Notifications.Core;
using Android.OS;
using Android.App;
using Android.Content;
using Java.Lang;
using Android.Content.Res;
using Android.Support.V4.App;
using Notifications.Android;

namespace Notifications
{
	public class AndroidPushNotificationProxy : IPushNotificationProxy
	{
		public static AndroidPushNotificationProxy Default { get; private set; }

		int _count;

		static readonly int ButtonClickNotificationId = 1000;

		public void OnNotificationRequest(Page sender, PushNotification args)
		{
			// These are the values that we want to pass to the next activity
			Bundle valuesForActivity = new Bundle ();
			valuesForActivity.PutInt ("count", _count);

			// Create the PendingIntent with the back stack             
			// When the user clicks the notification, SecondActivity will start up.
			var resultIntent = new Intent (Context, typeof(SecondActivity));
			resultIntent.PutExtras (valuesForActivity); // Pass some values to SecondActivity.

			var stackBuilder = TaskStackBuilder.Create (Context);
//			stackBuilder.AddParentStack (Class.FromType (typeof(SecondActivity)));
			stackBuilder.AddNextIntent (resultIntent);

			PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent (0, (int)PendingIntentFlags.UpdateCurrent);

			// Build the notification
			var builder = new NotificationCompat.Builder (Context)
				.SetAutoCancel (true) // dismiss the notification from the notification area when the user clicks on it
				.SetContentIntent (resultPendingIntent) // start up this activity when the user clicks the intent.
				.SetContentTitle ("Button Clicked") // Set the title
				.SetNumber (_count) // Display the count in the Content Info
				.SetSmallIcon (Resource.Drawable.icon) // This is the icon to display
				.SetContentText (System.String.Format ("The button has been clicked {0} times.", _count)); // the message to display.

			// Finally publish the notification
			var notificationManager = (NotificationManager)Context.GetSystemService (Context.NotificationService);
			notificationManager.Notify (ButtonClickNotificationId, builder.Build ());

			_count++;
		}

		readonly Context Context;

		public AndroidPushNotificationProxy (Context context)
		{
			Default = this;
			Context = context;
			MessagingCenter.Subscribe<Page,PushNotification>(Default, PushNotification.Subject, Default.OnNotificationRequest);
		}

	}
}

