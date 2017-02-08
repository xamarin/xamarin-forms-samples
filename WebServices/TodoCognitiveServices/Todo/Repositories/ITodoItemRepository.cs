using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo
{
	public interface ITodoItemRepository
	{
		Task<List<TodoItem>> GetAllItemsAsync();
		Task<TodoItem> GetItemAsync(int id);
		Task<int> SaveItemAsync(TodoItem item);
		Task<int> DeleteItemAsync(TodoItem item);
	}
}
