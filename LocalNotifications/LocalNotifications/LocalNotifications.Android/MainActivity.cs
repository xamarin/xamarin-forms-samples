using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Xamarin.Forms;

namespace LocalNotifications.Droid
{
    [Activity(Label = "LocalNotifications",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // handle notification taps that launched the activity
            CreateNotificationFromIntent(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            // handle notification taps if activity was already running
            CreateNotificationFromIntent(intent);
        }

        private void CreateNotificationFromIntent(Intent intent)
        {
            if(intent?.Extras != null)
            {
                var title = intent.Extras.GetString(AndroidNotificationManager.TitleKey);
                var message = intent.Extras.GetString(AndroidNotificationManager.MessageKey);

                DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
            }
        }
    }
}