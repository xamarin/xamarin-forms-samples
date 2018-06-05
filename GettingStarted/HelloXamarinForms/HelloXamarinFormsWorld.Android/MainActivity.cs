using Android.App;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HelloXamarinFormsWorld.Droid
{
    [Activity(Label = "HelloXamarinFormsWorld", Theme = "@style/MainTheme", MainLauncher = true)]
	public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

			LoadApplication (new App ());
        }
    }
}
