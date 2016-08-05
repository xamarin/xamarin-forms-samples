using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency (typeof(DeepLinking.Droid.SQLite))]
namespace DeepLinking.Droid
{
	public class SQLite : ISQLite
	{
		public SQLiteConnection GetConnection ()
		{
			string sqliteFilename = "TodoSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string path = Path.Combine (documentsPath, sqliteFilename);

			return new SQLiteConnection (path);
		}
	}
}
