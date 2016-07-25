using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace TodoREST.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif

			App.Speech = new Speech ();
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

