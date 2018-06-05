using Android.App;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


namespace XamarinFormsSample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MainTheme", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

			LoadApplication (new App());
        }
    }
}
