using System;
using Xamarin.Forms;
using WorkingWithFiles.Android;
using System.IO;
using System.Threading.Tasks;
using WorkingWithFiles;

[assembly: Dependency (typeof (SaveAndLoad_Android))]

namespace WorkingWithFiles.Android
{
	public class SaveAndLoad_Android : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		public async Task SaveTextAsync (string filename, string text)
		{
			var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(docsPath, filename);

			using (StreamWriter sw = File.CreateText(path))
			{
				await sw.WriteAsync(text);
			}
		}

		public async Task<string> LoadTextAsync (string filename)
		{
			string text;
			var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(docsPath, filename);

			using (StreamReader sr = File.OpenText(path))
			{
				text = await sr.ReadToEndAsync();
			}
			return text;
		}

		#endregion
	}
}

