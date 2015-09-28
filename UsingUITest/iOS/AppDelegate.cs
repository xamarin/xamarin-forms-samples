using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace UsingUITest.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			global::Xamarin.Forms.Forms.ViewInitialized += (sender, e) => {

				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
					Console.WriteLine("Set AccessibilityIdentifier: " + e.View.StyleId);
				}
			};

			LoadApplication(new App());

			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			return base.FinishedLaunching(app, options);
		}
	}
}

