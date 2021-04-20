using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoDocumentDB
{
	public interface IDocumentDBService
	{
		Task<bool> LoginAsync(Xamarin.Forms.Page page);

		Task<List<TodoItem>> GetTodoItemsAsync();

		Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

		Task DeleteTodoItemAsync(string id);
	}
}
