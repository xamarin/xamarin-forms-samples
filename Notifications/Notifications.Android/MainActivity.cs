using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Notifications.Core;

namespace Notifications.Android
{
    [Activity (Label = "Notifications.Android", MainLauncher = true)]
	public class MainActivity : Xamarin.Forms.Platform.Android.AndroidActivity
    {
        int count = 1;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

			SetPage(CreateRootPage());
        }

		static Page CreateRootPage ()
		{
			var page = new AppRootPage(new AndroidPushNotificationProxy(this));

			return page;
		}
    }
}


