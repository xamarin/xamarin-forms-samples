using System;
using TodoLocalized;
using Xamarin.Forms;
using System.IO;
using SQLite;

[assembly: Dependency (typeof (SQLite_iOS))]

namespace TodoLocalized
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		#region ISQLite implementation
		public SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "TodoSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			// This is where we copy in the prepopulated database
			Console.WriteLine (path);
			if (!File.Exists (path)) {
				File.Copy (sqliteFilename, path);
			}
				
			var conn = new SQLiteConnection(path);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}
