using System;
using Todo;
using Xamarin.Forms;
using Todo.iOS;
using System.IO;

[assembly: Dependency (typeof (SQLite_WinPhone))]

namespace Todo.WinPhone
{
	public class SQLite_WinPhone : ISQLite
	{
		public SQLite_WinPhone ()
		{
		}

		#region ISQLite implementation
		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "TodoSQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var plat = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}
