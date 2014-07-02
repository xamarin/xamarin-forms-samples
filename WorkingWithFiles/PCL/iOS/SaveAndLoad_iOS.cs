using System;
using Xamarin.Forms;
using WorkingWithFiles.iOS;

[assembly: Dependency (typeof (SaveAndLoad_iOS))]

namespace WorkingWithFiles.iOS
{
	public class SaveAndLoad_iOS : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		public void SaveText (string filename, string text)
		{
			System.IO.File.WriteAllText (filename, text);
		}

		public string LoadText (string filename)
		{
			return System.IO.File.ReadAllText (filename);
		}

		#endregion
	}
}

