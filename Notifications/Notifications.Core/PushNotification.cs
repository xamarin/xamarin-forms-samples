using System;
using Xamarin.Forms;

namespace Notifications.Core
{
	public class PushNotification
    {
		public static readonly string Subject = "Notifications.Push";

		public String Title { get; set; }

		public static void Send(Page sender, PushNotification notification)
		{
			MessagingCenter.Send(sender, Subject, notification);
		}
    }
}

