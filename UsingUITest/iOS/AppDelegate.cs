using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using MonoTouch.ObjCRuntime;

namespace UsingUITest
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		static readonly IntPtr setAccessibilityIdentifier_Handle = Selector.GetHandle("setAccessibilityIdentifier:");

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();


			// http://forums.xamarin.com/discussion/21148/calabash-and-xamarin-forms-what-am-i-missing
			Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {

				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
					Console.WriteLine("Set AccessibilityIdentifier: " + e.View.StyleId);
				}
			};


			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			window.RootViewController = App.GetMainPage ().CreateViewController ();
			window.MakeKeyAndVisible ();


			#if DEBUG
			// requires Xamarin Test Cloud Agent component
			Xamarin.Calabash.Start();
			#endif


			return true;
		}
	}
}

