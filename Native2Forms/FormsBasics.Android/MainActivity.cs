using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace Native2Forms
{
	/// <summary>
	/// This is a native Android screen. It will open a Xamarin.Forms screen.
	/// </summary>
	[Activity (Label = "Native2Forms", MainLauncher = true)]
	public class Activity1 : Activity
	{
		Button button;
		TextView label;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.Main);

			label = FindViewById<TextView> (Resource.Id.label);
			button = FindViewById<Button> (Resource.Id.button);

			button.Click += (sender, e) => {
				// this is our Xamarin.Forms screen
				StartActivity(typeof(FormsActivity));
			};
		}
	}
}


