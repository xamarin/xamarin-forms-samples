using System;
using System.IO;
using TodoLocalized;
using TodoLocalized.WinPhone;
using Xamarin.Forms;
using Windows.Storage;

[assembly: Dependency (typeof (SQLite_WinPhone))]

namespace TodoLocalized
{
	public class SQLite_WinPhone : ISQLite
	{
		public SQLite_WinPhone ()
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
