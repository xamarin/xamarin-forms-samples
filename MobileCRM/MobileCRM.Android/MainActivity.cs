using Android;
using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin;
using MobileCRM;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

/*

Welcome to the Xamarin.Forms MobileCRM sample app for Android.

Please note that the MAP view will NOT WORK until you have generated your *own* Google Maps API V2 Key.

Follow the instructions on this page (under Platform Configuration)
     http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/maps/
which will require you to visit the Google Developer Console here:
     https://console.developers.google.com/
note the package name is "com.xamarin.mobilecrm". If you change this in the 
Project > Options > Android Application screen, use your updated value in the 
API Key configuration on the Google Developer Console.

The API Key generated on the Google Developer Console should be added to the 
AndroidManifest.xml file in the Properties folder. Open the file and click 'Source'
at the bottom of the window to edit the XML directly.

*/
namespace MobileCRMAndroid
{
    [Activity(Label = "MobileCRM", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        const int RequestAccessFineLocation = 1;
        bool wasInitialized = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // init Forms components
            MobileCRMApp.Init(typeof(MobileCRMApp).Assembly);
            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);

            // check for permissions in Runtime
            var permissionCheck = ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation);
            if (!permissionCheck.Equals(Permission.Granted))
            {
                // there is no granted permission to ACCESS_FINE_LOCATION. Requesting it in runtime
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, RequestAccessFineLocation);
            }
            else
            {
                // the permission was granted in the past
                InitApp();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode != RequestAccessFineLocation) return;

            // If request is cancelled, the result arrays are empty.
            if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                // permission was granted
                // Start app
                wasInitialized = true;
                InitApp();
            }
            else
            {
                // permission denied
                // close app
                Finish();
            }
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            return wasInitialized && base.OnPrepareOptionsMenu(menu);
        }

        private void InitApp()
        {
            if (IsGooglePlayServicesInstalled())
            {
                LoadApplication(new App());
            }
            else
            {
                Toast.MakeText(this, "Google Play Service is not installed", ToastLength.Long).Show();
            }
        }

        private bool IsGooglePlayServicesInstalled()
        {
            var googleApiAvailability = GoogleApiAvailability.Instance;
            var status = googleApiAvailability.IsGooglePlayServicesAvailable(this);
            return status == ConnectionResult.Success;
        }
    }
}


