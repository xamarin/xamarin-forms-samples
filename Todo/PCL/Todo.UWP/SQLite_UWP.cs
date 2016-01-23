using System;
using System.IO;
using Todo;
using Xamarin.Forms;
using Windows.Storage;
using Todo.UWP;

[assembly: Dependency (typeof (SQLite_UWP))]

namespace Todo.UWP
{
	public class SQLite_UWP : ISQLite
	{
		public SQLite_UWP ()
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
