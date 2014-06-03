using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;

namespace TablesLists.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow window;
		private string[] filesToCopy = new string[] {
			"MainMenuItems.xml", "PlainTable.xml", "DefaultCellStyle.xml"
		};

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			foreach (var filename in filesToCopy) {
				CopyInfoIntoWorkingFolder (filename);
			}

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = App.GetMainPage ().CreateViewController ();
			window.MakeKeyAndVisible ();
			
			return true;
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

