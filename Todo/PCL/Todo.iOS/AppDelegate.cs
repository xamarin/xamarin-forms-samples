using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Todo
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();
			LoadApplication (new App ());
			return base.FinishedLaunching (app, options);
		}
	}
}