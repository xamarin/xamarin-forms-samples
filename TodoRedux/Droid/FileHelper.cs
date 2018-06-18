using System;
using System.IO;
using TodoRedux.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(TodoRedux.Droid.FileHelper))]
namespace TodoRedux.Droid
{
	public class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}