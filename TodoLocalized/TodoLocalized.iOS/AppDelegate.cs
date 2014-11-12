using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TodoLocalized;
using Xamarin.Forms;
using System.IO;
using System.Threading;

namespace TodoLocalized
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			#region Localization debug info
			foreach (var s in NSLocale.PreferredLanguages) {
				Console.WriteLine ("pref:" + s);
			}

			var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
			var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;
			Console.WriteLine ("nslocaleid:" + iosLocaleAuto);
			Console.WriteLine ("nslanguage:" + iosLanguageAuto);


			var iosLocale = NSLocale.CurrentLocale.LocaleIdentifier;
			var iosLanguage = NSLocale.CurrentLocale.LanguageCode;
			var netLocale = iosLocale.Replace ("_", "-");
			var netLanguage = iosLanguage.Replace ("_", "-");
			Console.WriteLine ("ios:" + iosLanguage + " " + iosLocale);
			Console.WriteLine ("net:" + netLanguage + " " +  netLocale);

			Console.WriteLine ("culture:" + Thread.CurrentThread.CurrentCulture);
			Console.WriteLine ("uiculture:" + Thread.CurrentThread.CurrentUICulture);
			#endregion

			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			// If you have defined a view, add it here:
			// window.RootViewController  = navigationController;
			window.RootViewController = App.GetMainPage ().CreateViewController ();

			// make the window visible
			window.MakeKeyAndVisible ();

			return true;
		}
	}
}