using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                //added CreateFlags.None to avoid exception
                database.CreateTable<TodoItem>(CreateFlags.None);
            }
            catch (System.Exception exception)
            {

                Debug.WriteLine("Ex1234: "  + exception.Message);
            }
			
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

