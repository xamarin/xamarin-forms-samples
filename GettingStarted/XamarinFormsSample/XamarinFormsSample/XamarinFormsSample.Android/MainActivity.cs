using Android.App;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


namespace XamarinFormsSample.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

			LoadApplication (new App());
        }
    }
}
