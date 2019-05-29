using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Iid;
using System;
using WindowsAzure.Messaging;

namespace NotificationHubSample.Droid
{
    [Service]
    [IntentFilter(new [] { "com.google.firebase.INSTANCE_ID_EVENT"})]
    public class FirebaseRegistrationService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            string token = FirebaseInstanceId.Instance.Token;

            // NOTE: logging the token is not recommended in production but during
            // development it is useful to test messages directly from Firebase
            Log.Info(AppConstants.DebugTag, $"Token received: {token}");

            SendRegistrationToServer(token);
        }

        void SendRegistrationToServer(string token)
        {
            try
            {
                NotificationHub hub = new NotificationHub(AppConstants.NotificationHubName, AppConstants.ListenConnectionString, this);

                // register device with Azure Notification Hub using the token from FCM
                Registration reg = hub.Register(token, AppConstants.SubscriptionTags);

                // subscribe to the SubscriptionTags list with a simple template.
                string pnsHandle = reg.PNSHandle;
                var cats = string.Join(", ", reg.Tags);
                var temp = hub.RegisterTemplate(pnsHandle, "defaultTemplate", AppConstants.FCMTemplateBody, AppConstants.SubscriptionTags);
            }
            catch(Exception e)
            {
                Log.Error(AppConstants.DebugTag, $"Error registering device: {e.Message}");
            }
        }
    }
}