using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin;
using MobileCRM.Shared.Pages;
using MobileCRM;
using Android.Graphics.Drawables;
using Android.Content.PM;
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
    [Activity (Label = "MobileCRM", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            MobileCRMApp.Init(typeof(MobileCRMApp).Assembly);
            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);

			LoadApplication (new App ());
        }
    }
}


