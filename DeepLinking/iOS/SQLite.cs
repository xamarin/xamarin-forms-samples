using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency (typeof(DeepLinking.iOS.SQLite))]
namespace DeepLinking.iOS
{
	public class SQLite : ISQLite
	{
		public global::SQLite.SQLiteConnection GetConnection ()
		{
			string sqliteFilename = "TodoSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library");
			var path = Path.Combine (libraryPath, sqliteFilename);

			return new SQLiteConnection (path);
		}
	}
}

