using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoDocumentDB
{
	public class TodoItemManager
	{
		IDocumentDBService documentDBService;

		public TodoItemManager(IDocumentDBService service)
		{
			documentDBService = service;
		}

		public Task<bool> LoginAsync(Xamarin.Forms.Page page)
		{
			return documentDBService.LoginAsync(page);
		}

		public Task<List<TodoItem>> GetTodoItemsAsync()
		{
			return documentDBService.GetTodoItemsAsync();
		}

		public Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
		{
			return documentDBService.SaveTodoItemAsync(item, isNewItem);
		}

		public Task DeleteTodoItemAsync(TodoItem item)
		{
			return documentDBService.DeleteTodoItemAsync(item.Id);
		}
	}
}
