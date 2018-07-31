using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoCognitive
{
	public interface ITodoItemRepository
	{
		Task<List<TodoItem>> GetAllItemsAsync();
		Task<TodoItem> GetItemAsync(int id);
		Task<int> SaveItemAsync(TodoItem item);
		Task<int> DeleteItemAsync(TodoItem item);
	}
}
