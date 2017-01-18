using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Todo
{
	public class TodoItemDatabase
	{
		readonly SQLiteAsyncConnection database;

		public TodoItemDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<TodoItem>().Wait();
		}

		public Task<List<TodoItem>> GetItemsAsync()
		{
			return database.Table<TodoItem>().ToListAsync();
		}

		public Task<List<TodoItem>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
		}

		public Task<TodoItem> GetItemAsync(int id)
		{
			return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(TodoItem item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(TodoItem item)
		{
			return database.DeleteAsync(item);
		}
	}
}

