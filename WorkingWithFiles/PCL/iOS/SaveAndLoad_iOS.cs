using System;
using Xamarin.Forms;
using WorkingWithFiles.iOS;
using System.IO;
using System.Threading.Tasks;
using WorkingWithFiles;
using Foundation;
using System.Linq;

[assembly: Dependency (typeof(SaveAndLoad_iOS))]

namespace WorkingWithFiles.iOS
{
	public class SaveAndLoad_iOS : ISaveAndLoad
	{
		public static string DocumentsPath {
			get {
				var documentsDirUrl = NSFileManager.DefaultManager.GetUrls (NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User).Last ();
				return documentsDirUrl.Path;
			}
		}

		#region ISaveAndLoad implementation

		public async Task SaveTextAsync (string filename, string text)
		{
			string path = BuildPathForDocumentsDir (filename);
			using (StreamWriter sw = File.CreateText(path))
			{
				await sw.WriteAsync(text);
			}
		}

		public async Task<string> LoadTextAsync (string filename)
		{
			string path = BuildPathForDocumentsDir (filename);
			using (StreamReader sr = File.OpenText(path))
			{
				return await sr.ReadToEndAsync();
			}
		}

		#endregion

		static string BuildPathForDocumentsDir(string fileName)
		{
			return Path.Combine (DocumentsPath, fileName);
		}
	}
}

