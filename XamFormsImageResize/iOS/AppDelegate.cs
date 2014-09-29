using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

namespace XamFormsImageResize.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UIViewController _home;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			HomePage home = new HomePage ();
			this._home = home.CreateViewController ();
			
			window.RootViewController = this._home;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

