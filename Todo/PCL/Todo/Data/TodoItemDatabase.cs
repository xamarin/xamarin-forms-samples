using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Todo
{
	public class TodoItemDatabase 
	{
		static object locker = new object ();

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public TodoItemDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			database.CreateTable<TodoItem>();
		}

		public IEnumerable<TodoItem> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<TodoItem>() select i).ToList();
			}
		}

		public IEnumerable<TodoItem> GetItemsNotDone ()
		{
			lock (locker) {
				return database.Query<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
			}
		}

		public TodoItem GetItem (int id) 
		{
			lock (locker) {
				return database.Table<TodoItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem (TodoItem item) 
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				} else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<TodoItem>(id);
			}
		}
	}
}

