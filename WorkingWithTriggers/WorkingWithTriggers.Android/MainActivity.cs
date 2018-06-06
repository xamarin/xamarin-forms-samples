using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace WorkingWithTriggers.Droid
{
    [Activity(Label = "Triggers", 
		Theme = "@style/MainTheme", MainLauncher = true,
		ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize
	)]
	public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication (new App ());
        }
    }
}

