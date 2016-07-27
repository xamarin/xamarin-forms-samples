using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoParse
{
	public class TodoItemManager
	{
		IParseStorage storage;

		public TodoItemManager (IParseStorage parseStorage)
		{
			storage = parseStorage;
		}

		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return storage.RefreshDataAsync ();
		}

		public Task SaveTaskAsync (TodoItem item)
		{
			return storage.SaveTodoItemAsync (item);
		}

		public Task DeleteTaskAsync (TodoItem item)
		{
			return storage.DeleteTodoItemAsync (item);
		}

		public Task<bool> SignUpUserAsync (User user)
		{
			return storage.SignUpUserAsync (user);
		}

		public Task<bool> LoginUserAsync (User user)
		{
			return storage.LoginUserAsync (user);
		}

		public bool IsUserLoggedIn ()
		{
			return storage.IsUserLoggedIn ();
		}

		public Task LogoutAsync ()
		{
			return storage.LogoutAsync ();
		}
	}
}

