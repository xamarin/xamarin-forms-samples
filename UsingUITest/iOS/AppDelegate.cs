using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using ObjCRuntime;

namespace UsingUITest
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : 
	global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate // superclass new in 1.3
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			global::Xamarin.Forms.Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {

				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
					Console.WriteLine("Set AccessibilityIdentifier: " + e.View.StyleId);
				}
			};

			LoadApplication (new App ());  // method is new in 1.3


			#if DEBUG
			// requires Xamarin Test Cloud Agent component
			Xamarin.Calabash.Start();
			#endif

			return base.FinishedLaunching (app, options);
		}
	}
}

