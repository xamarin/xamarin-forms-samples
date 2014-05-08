using System;
using Xamarin.Forms;
using Notifications.Core;
using Android.OS;
using Android.App;
using Notifications.Android;

namespace Notifications
{
	
	[Activity(Label = "Second Activity")]
	public class SecondActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			int count = Intent.Extras.GetInt ("count", -1);
			if (count <= 0) {
				return;
			}

			NotificationsApp
			TextView txtView = FindViewById<TextView> (Resource.Id.textView1);
			txtView.Text = String.Format ("You clicked the button {0} times in the previous activity.", count);
		}
	}
}
