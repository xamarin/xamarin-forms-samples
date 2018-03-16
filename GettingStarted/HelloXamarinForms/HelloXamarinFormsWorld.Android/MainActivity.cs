using Android.App;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HelloXamarinFormsWorld.Droid
{
    [Activity(Label = "HelloXamarinFormsWorld", MainLauncher = true)]
	public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

			LoadApplication (new App ());
        }
    }
}
