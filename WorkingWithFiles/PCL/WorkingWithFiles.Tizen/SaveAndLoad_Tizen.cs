using Xamarin.Forms;
using WorkingWithFiles.Tizen;
using System.IO;
using System.Threading.Tasks;

[assembly: Dependency(typeof(SaveAndLoad_Tizen))]
namespace WorkingWithFiles.Tizen
{
	public class SaveAndLoad_Tizen : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		public async Task SaveTextAsync (string filename, string text)
		{
			var path = CreatePathToFile (filename);
			using (StreamWriter sw = File.CreateText (path))
				await sw.WriteAsync(text);
		}

		public async Task<string> LoadTextAsync (string filename)
		{
			var path = CreatePathToFile (filename);
			using (StreamReader sr = File.OpenText(path))
				return await sr.ReadToEndAsync();
		}

		public bool FileExists (string filename)
		{
			return File.Exists (CreatePathToFile (filename));
		}

		#endregion

		string CreatePathToFile (string filename)
		{
			var docsPath = global::Tizen.Applications.Application.Current.DirectoryInfo.Data;
			return Path.Combine(docsPath, filename);
		}
	}
}