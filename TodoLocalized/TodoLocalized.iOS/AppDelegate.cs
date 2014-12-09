using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using TodoLocalized;
using Xamarin.Forms;
using System.IO;
using System.Threading;

namespace TodoLocalized
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : 
	global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate // superclass new in 1.3
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());  // method is new in 1.3

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

			return base.FinishedLaunching (app, options);
		}
	}
}

