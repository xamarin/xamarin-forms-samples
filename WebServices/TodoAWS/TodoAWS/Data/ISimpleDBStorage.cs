using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoAWSSimpleDB
{
	public interface ISimpleDBStorage
	{
		Task<List<TodoItem>> RefreshDataAsync();

		Task SaveTodoItemAsync (TodoItem item);

		Task DeleteTodoItemAsync (TodoItem id);
	}
}