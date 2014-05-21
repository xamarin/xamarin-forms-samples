using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using System.IO;
using EmployeeDirectory;

namespace EmployeeDirectory.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			CopyInfoIntoWorkingFolder ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = EmployeeDirectoryCSharp.App.GetMainPage ().CreateViewController ();
			EmployeeDirectoryCSharp.App.PhoneFeatureService = new iOSPhoneFeatureService (window.RootViewController);

			window.MakeKeyAndVisible ();

			return true;
		}

		private void CopyInfoIntoWorkingFolder ()
		{
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = documentsPath.Replace ("Documents", "Library");

			var path = Path.Combine (libraryPath, "XamarinDirectory.csv");
			if (!File.Exists (path)) {
				File.Copy ("XamarinDirectory.csv", path);
			}
			path = Path.Combine (libraryPath, "XamarinFavorites.xml");

			if (!File.Exists (path)) {
				File.Copy ("XamarinFavorites.xml", path);
			}
		}
	}
}

