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

		public Task CreateDatabase(string databaseName)
		{
			return documentDBService.CreateDatabase(databaseName);
		}

		public Task CreateDocumentCollection(string databaseName, string collectionName)
		{
			return documentDBService.CreateDocumentCollection(databaseName, collectionName);
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
