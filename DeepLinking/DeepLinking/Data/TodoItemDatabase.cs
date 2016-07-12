using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace DeepLinking
{
	public class TodoItemDatabase
	{
		static readonly object locker = new object ();
		readonly SQLiteConnection database;

		public TodoItemDatabase ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<TodoItem> ();
		}

		public IEnumerable<TodoItem> GetItems ()
		{
			lock (locker) {
				return database.Table<TodoItem> ().ToList ();
			}
		}

		public TodoItem Find (string id)
		{
			lock (locker) {
				return database.Table<TodoItem> ().FirstOrDefault (i => i.ID == id);
			}
		}

		public int Insert (TodoItem item)
		{
			lock (locker) {
				return database.Insert (item);
			}
		}

		public int Update (TodoItem item)
		{
			lock (locker) {
				return database.Update (item);
			}
		}

		public int Delete (string id)
		{
			lock (locker) {
				return database.Delete<TodoItem> (id);
			}
		}
	}
}

