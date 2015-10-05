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
	}
}
