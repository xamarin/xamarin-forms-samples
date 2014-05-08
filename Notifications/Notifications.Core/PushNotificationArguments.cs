using System;
using Xamarin.Forms;

namespace Notifications
{
	public class PushNotificationArguments
	{
		public string Title { get; private set; }

		public PushNotificationArguments(String title)
		{
			Title = title;
		}
	}

}

