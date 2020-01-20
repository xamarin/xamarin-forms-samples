using Android.App;
using Android.OS;
using Android.Content.PM;

namespace WorkingWithFonts.Android
{
	[Activity(Label = "Fonts", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity :
	global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}
	}


}

