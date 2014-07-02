using System;
using Xamarin.Forms;
using WorkingWithFiles.Android;
using System.IO;
using System.Threading.Tasks;

[assembly: Dependency (typeof (SaveAndLoad_Android))]

namespace WorkingWithFiles.Android
{
	public class SaveAndLoad_Android : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		public void SaveText (string filename, string text)
		{
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			var filePath = Path.Combine (documentsPath, filename);
			System.IO.File.WriteAllText (filePath, text);
		}

		public string LoadText (string filename)
		{
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			var filePath = Path.Combine (documentsPath, filename);
			return System.IO.File.ReadAllText (filePath);
		}

		#endregion
	}
}

