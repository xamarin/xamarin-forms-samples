using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoParse
{
	public interface IParseStorage
	{
		Task<List<TodoItem>> RefreshDataAsync ();

		Task SaveTodoItemAsync (TodoItem item);

		Task DeleteTodoItemAsync (TodoItem id);

		Task<bool> SignUpUserAsync (User user);

		Task<bool> LoginUserAsync (User user);

		bool IsUserLoggedIn ();

		Task LogoutAsync ();
	}
}
