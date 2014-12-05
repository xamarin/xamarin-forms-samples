using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System.IO;
using EmployeeDirectory;
using EmployeeDirectoryUI;
using Xamarin.Forms.Platform.iOS;

namespace EmployeeDirectory.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			CopyInfoIntoWorkingFolder ("XamarinDirectory.csv");
			CopyInfoIntoWorkingFolder ("XamarinFavorites.xml");

			LoadApplication (new App());

			var b = base.FinishedLaunching (app,options);

			App.PhoneFeatureService = new iOSPhoneFeatureService (app.KeyWindow.RootViewController);

			return b;
		}

		private void CopyInfoIntoWorkingFolder (string fileName)
		{
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = documentsPath.Replace ("Documents", "Library");

			var path = Path.Combine (libraryPath, fileName);
			if (!File.Exists (path)) {
				File.Copy (fileName, path);
			}
		}
	}
}

