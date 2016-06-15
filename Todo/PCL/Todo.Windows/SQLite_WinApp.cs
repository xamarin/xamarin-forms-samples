using System;
using System.IO;
using Todo;
using Todo.UWP;
using Xamarin.Forms;
using Windows.Storage;

[assembly: Dependency (typeof (SQLite_WinApp))]

namespace Todo.UWP
{
	public class SQLite_WinApp : ISQLite
	{
		public SQLite_WinApp ()
		{
		}
		#region ISQLite implementation
		public SQLite.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "TodoSQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}
