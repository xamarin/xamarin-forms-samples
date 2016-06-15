using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace InsightsXamarinFormsTest
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);

			// NOTE* The initialization for Insights is in Main.cs, before the AppDelegate is initialized
		}
	}
}

