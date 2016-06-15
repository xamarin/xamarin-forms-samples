using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Forms.Platform.Android;

namespace Native2Forms
{
	/// <summary>
	/// This is a native Android screen. It will open a Xamarin.Forms screen.
	/// </summary>
	[Activity (Label = "Native2Forms", MainLauncher = true)]
	public class Activity1 : FormsApplicationActivity
	{
		Button button;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Native2Forms.Android.Resource.Layout.Main);

			button = FindViewById<Button> (Native2Forms.Android.Resource.Id.button);

			button.Click += (sender, e) => {
				// this is our Xamarin.Forms screen
				StartActivity(typeof(FormsActivity));
			};

			Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new App ());
		}
	}
}


