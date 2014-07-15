using System;
using Xamarin.Forms;
using WorkingWithFiles.iOS;
using System.IO;
using System.Threading.Tasks;

[assembly: Dependency (typeof (SaveAndLoad_iOS))]

namespace WorkingWithFiles.iOS
{
	public class SaveAndLoad_iOS : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		public async Task SaveTextAsync (string filename, string text)
		{
			using (StreamWriter sw = File.CreateText(filename))
			{
				await sw.WriteAsync(text);
			}
		}

		public async Task<string> LoadTextAsync (string filename)
		{
			string text;

			using (StreamReader sr = File.OpenText(filename))
			{
				text = await sr.ReadToEndAsync();
			}
			return text;
		}

		#endregion
	}
}

