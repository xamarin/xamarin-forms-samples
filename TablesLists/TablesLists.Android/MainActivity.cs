using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using System.IO;

namespace TablesLists.Android
{
	[Activity (Label = "TablesLists.Android", MainLauncher = true)]
	public class MainActivity : Xamarin.Forms.Platform.Android.AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			CopyInfoIntoWorkingFolder ("MainMenuItems.xml", TablesLists.Android.Resource.Raw.MainMenuItems);
			CopyInfoIntoWorkingFolder ("SimpleListItem1.xml", TablesLists.Android.Resource.Raw.SimpleListItem1);
			CopyInfoIntoWorkingFolder ("SimpleListItem2.xml", TablesLists.Android.Resource.Raw.SimpleListItem2);
			CopyInfoIntoWorkingFolder ("ActivityListItem.xml", TablesLists.Android.Resource.Raw.ActivityListItem);
			CopyInfoIntoWorkingFolder ("DateList.xml", TablesLists.Android.Resource.Raw.DateList);
			CopyInfoIntoWorkingFolder ("LabelledSections.xml", TablesLists.Android.Resource.Raw.LabelledSections);

			Forms.Init (this, bundle); 
			SetPage (App.GetMainPage ());
		}

		private void CopyInfoIntoWorkingFolder (string fileName, int resourceId)
		{
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			var path = Path.Combine (documentsPath, fileName);

			if (!File.Exists (path)) {
				var resource = Resources.OpenRawResource (resourceId);
				var writeStream = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Write);
				ReadWriteStream (resource, writeStream);
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


