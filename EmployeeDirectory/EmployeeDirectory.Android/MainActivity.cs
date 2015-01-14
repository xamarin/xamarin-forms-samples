using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using EmployeeDirectory;
using EmployeeDirectoryUI;
using Android.Content.PM;

namespace EmployeeDirectory.Android
{
	[Activity (Label = "EmployeeDirectory", MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class Activity1 : Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			CopyInfoIntoWorkingFolder ("XamarinDirectory.csv",
				EmployeeDirectory.Android.Resource.Raw.XamarinDirectory);
			CopyInfoIntoWorkingFolder ("XamarinFavorites.xml",
				EmployeeDirectory.Android.Resource.Raw.XamarinFavorites);

			Xamarin.Forms.Forms.Init (this, bundle);

			App.PhoneFeatureService = new AndroidPhoneFeatureService ();

			LoadApplication (new App ());
		}

		private void CopyInfoIntoWorkingFolder (string fileName, int resourceId)
		{
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			var path = Path.Combine (documentsPath, fileName);

			if (!File.Exists (path)) {
				var readStream = Resources.OpenRawResource (resourceId);
				var writeStream = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Write);
				ReadWriteStream (readStream, writeStream);
			}
		}

		private void ReadWriteStream (Stream readStream, Stream writeStream)
		{
			int Length = 256;
			var buffer = new Byte[Length];
			int bytesRead = readStream.Read (buffer, 0, Length);

			using (readStream)
			using (writeStream) {
				while (bytesRead > 0) {
					writeStream.Write (buffer, 0, bytesRead);
					bytesRead = readStream.Read (buffer, 0, Length);
				}
			}
		}
	}
}


