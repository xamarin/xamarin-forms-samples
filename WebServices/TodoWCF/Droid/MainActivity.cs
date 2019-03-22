using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TodoWCF.Droid
{
    [Activity(Label = "TodoWCF.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);

            App.Speech = new Speech();
            
            // NOTE: Android emulator cannot access localhost but must
            // use a local proxy. You may need to change this if testing
            // on a device.
            App.SoapUrl = "http://10.0.2.2:49393/TodoService.svc";

            LoadApplication(new App());
        }
    }
}

