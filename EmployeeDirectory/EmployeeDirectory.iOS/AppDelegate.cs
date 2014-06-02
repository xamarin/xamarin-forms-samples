using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using System.IO;
using EmployeeDirectory;
using EmployeeDirectoryUI;

namespace EmployeeDirectory.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			CopyInfoIntoWorkingFolder ("XamarinDirectory.csv");
			CopyInfoIntoWorkingFolder ("XamarinFavorites.xml");

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = App.GetMainPage ().CreateViewController ();
			App.PhoneFeatureService = new iOSPhoneFeatureService (window.RootViewController);

			window.MakeKeyAndVisible ();

			return true;
		}

		private void CopyInfoIntoWorkingFolder (string fileName)
		{
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = documentsPath.Replace ("Documents", "Library");

			var path = Path.Combine (libraryPath, fileName);
			if (!File.Exists (path))
				File.Copy (fileName, path);
		}
	}
}

