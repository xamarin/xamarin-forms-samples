using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoASMX
{
	public interface ISoapService
	{
		Task<List<TodoItem>> RefreshDataAsync ();

		Task SaveTodoItemAsync (TodoItem item, bool isNewItem);

		Task DeleteTodoItemAsync (string id);
	}
}
