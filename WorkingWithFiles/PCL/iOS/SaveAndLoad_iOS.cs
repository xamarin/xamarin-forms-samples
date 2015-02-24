using System;
using Xamarin.Forms;
using WorkingWithFiles.iOS;
using System.IO;
using System.Threading.Tasks;
using WorkingWithFiles;

[assembly: Dependency (typeof(SaveAndLoad_iOS))]

namespace WorkingWithFiles.iOS
{
	public class SaveAndLoad_iOS : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		public async Task SaveTextAsync (string filename, string text)
		{
			string file = Path.Combine (
				              Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), 
				              "..", "Library", filename);
			using (StreamWriter sw = File.CreateText (file)) {
				await sw.WriteAsync (text);
			}
		}

		public async Task<string> LoadTextAsync (string filename)
		{
			string file = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), 
				"..", "Library", filename);
			string text;

			using (StreamReader sr = File.OpenText (file)) {
				text = await sr.ReadToEndAsync ();
			}
			return text;
		}

		#endregion
	}
}

