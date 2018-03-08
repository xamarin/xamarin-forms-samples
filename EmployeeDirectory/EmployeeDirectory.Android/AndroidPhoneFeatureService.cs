using System;
using Android.Content;
using Xamarin.Forms;
using EmployeeDirectoryUI;
using Android;

namespace EmployeeDirectory.Android
{
    public class AndroidPhoneFeatureService : IPhoneFeatureService, MainActivity.IPermissionCallback
    {
        readonly static int REQUEST_CODE_CALL_PHONE = 0;

        MainActivity owner;
        object currentData;

        public AndroidPhoneFeatureService(MainActivity owner)
        {
            this.owner = owner;
        }

        public bool Email(string emailAddress)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("message/rfc822");
            intent.PutExtra(Intent.ExtraEmail, new[] { emailAddress });
            MainActivity.Instance.StartActivity(Intent.CreateChooser(intent, "Send email"));

            return true;
        }

        public bool Browse(string websiteUrl)
        {
            var url = websiteUrl.ToUpperInvariant().StartsWith("HTTP") ?
                websiteUrl :
                "http://" + websiteUrl;

            var intent = new Intent(Intent.ActionView, global::Android.Net.Uri.Parse(url));
            MainActivity.Instance.StartActivity(intent);

            return true;
        }

        public bool Tweet(string twitterName)
        {
            var username = twitterName.Trim();
            if (username.StartsWith("@"))
                username = username.Substring(1);

            var url = "http://twitter.com/" + username;
            var intent = new Intent(Intent.ActionView, global::Android.Net.Uri.Parse(url));
            MainActivity.Instance.StartActivity(intent);

            return true;
        }

        public bool Call(string phoneNumber)
        {
            // keep the phone number
            currentData = phoneNumber;

            // ask runtime permission
            owner.AskForPermission(Manifest.Permission.CallPhone, REQUEST_CODE_CALL_PHONE, this);

            return true;
        }

        public bool Map(string address)
        {
            throw new NotImplementedException("This wasn't implemented in the original Android app...");
        }

        public void OnGrantedPermission(int requestCode)
        {
            if (requestCode == REQUEST_CODE_CALL_PHONE)
            {
                MakeCall((string)currentData);
            }
        }

        public void OnDeniedPermission(int requestCode)
        {
            if (requestCode == REQUEST_CODE_CALL_PHONE)
            {
                owner.ShowToast("Call Phone permission was denied");
            }
        }

        private void MakeCall(string phoneNumber)
        {
            var intent = new Intent(Intent.ActionCall, global::Android.Net.Uri.Parse(
                             "tel:" + Uri.EscapeDataString(phoneNumber)));
            MainActivity.Instance.StartActivity(intent);
        }

    }
}

