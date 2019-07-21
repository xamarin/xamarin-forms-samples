using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ThemesDemo.Droid
{
	[Activity (Label = "ThemesDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate (bundle);
			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new App ());

			var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
			x = typeof(Xamarin.Forms.Themes.LightThemeResources);
			x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
		}
	}
}

