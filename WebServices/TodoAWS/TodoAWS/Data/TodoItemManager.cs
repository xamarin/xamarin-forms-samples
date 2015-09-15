using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoAWSSimpleDB
{
	public class TodoItemManager
	{
		ISimpleDBStorage storage;

		public TodoItemManager (ISimpleDBStorage simpleDBStorage)
		{
			storage = simpleDBStorage;
		}

		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return storage.RefreshDataAsync();
		}

		public Task SaveTaskAsync (TodoItem item)
		{
			return storage.SaveTodoItemAsync(item);
		}

		public Task DeleteTaskAsync (TodoItem item)
		{
			return storage.DeleteTodoItemAsync(item);
		}
	}
}
