using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using Foundation;
using Microsoft.Azure.Mobile;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Todo
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// affects all UISwitch controls in the app
			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0x91, 0xCA, 0x47);

			Forms.Init ();
			MobileCenter.Configure("68befc9c-64bd-4748-a4a3-47e56f15673f");
			LoadApplication (new App ());
			return base.FinishedLaunching (app, options);
		}
	}
}