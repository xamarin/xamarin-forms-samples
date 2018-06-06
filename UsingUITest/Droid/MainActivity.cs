using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace UsingUITest.Droid
{
	[Activity (Label = "UsingUITest.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			// NOTE: this is no longer required - Xamarin.Forms 2.2 now AUTOMATICALLY
			// assigns the "AutomationId" to the "ContentDescription"
			//global::Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
			//	if (!string.IsNullOrWhiteSpace (e.View.AutomationId)) {
			//		e.NativeView.ContentDescription = e.View.AutomationId;
			//	}
			//};

			LoadApplication (new App ());
		}
	}
}

