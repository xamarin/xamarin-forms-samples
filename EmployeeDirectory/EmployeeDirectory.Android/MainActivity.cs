using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using EmployeeDirectory;

namespace EmployeeDirectory.Android
{
	[Activity (Label = "EmployeeDirectory", MainLauncher = true)]
	public class Activity1 : Xamarin.Forms.Platform.Android.AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			CopyInfoIntoWorkingFolder ();

			Xamarin.Forms.Forms.Init (this, bundle);
			EmployeeDirectoryCSharp.App.PhoneFeatureService = new AndroidPhoneFeatureService ();
			SetPage (EmployeeDirectoryCSharp.App.GetMainPage ());
		}

		private void CopyInfoIntoWorkingFolder ()
		{
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			var path = Path.Combine (documentsPath, "XamarinDirectory.csv");

			if (!File.Exists (path)) {
				var s = Resources.OpenRawResource (EmployeeDirectory.Android.Resource.Raw.XamarinDirectory);
				// create a write stream
				var writeStream = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Write);
				// write to the stream
				ReadWriteStream (s, writeStream);
			}
			path = Path.Combine (documentsPath, "XamarinFavorites.xml");

			if (!File.Exists (path)) {
				var s = Resources.OpenRawResource (EmployeeDirectory.Android.Resource.Raw.XamarinFavorites);
				// create a write stream
				var writeStream = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Write);
				// write to the stream
				ReadWriteStream (s, writeStream);
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


