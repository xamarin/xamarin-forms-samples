using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using System.Threading.Tasks;
using Firebase.Iid;
using Android.Util;
using Android.Content;

namespace NotificationHubSample.Droid
{
    [Activity(Label = "NotificationHubSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode =LaunchMode.SingleTop)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            IsPlayServiceAvailable();
            CreateNotificationChannel();

            Log.Info(AppConstants.DebugTag, $"App starting with token: {FirebaseInstanceId.Instance.Token}");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void ForceRefreshIdToken()
        {
            // this can't be run on the UI thread
            Task.Run(() =>
            {
                Log.Info(AppConstants.DebugTag, "ForceRefreshIdToken called, deleting instance id");
                FirebaseInstanceId.Instance.DeleteInstanceId();
            });
        }

        protected override void OnNewIntent(Intent intent)
        {
            if (intent.Extras != null)
            {
                var message = intent.GetStringExtra("message");
                (App.Current.MainPage as MainPage)?.AddMessage(message);
            }

            base.OnNewIntent(intent);
        }

        bool IsPlayServiceAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Debug(AppConstants.DebugTag, GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Log.Debug(AppConstants.DebugTag, "This device is not supported");
                    Finish();
                }
                return false;
            }
            return true;
        }

        void CreateNotificationChannel()
        {
            // Notification channels are new as of "Oreo".
            // There is no need to create a notification channel on older versions of Android.
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelName = AppConstants.NotificationChannelName;
                var channelDescription = String.Empty;
                var channel = new NotificationChannel(channelName, channelName, NotificationImportance.Default)
                {
                    Description = channelDescription
                };

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }
    }
}