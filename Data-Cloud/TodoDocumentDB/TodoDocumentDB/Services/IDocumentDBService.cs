using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoDocumentDB
{
	public interface IDocumentDBService
	{
		Task CreateDatabase(string databaseName);

		Task CreateDocumentCollection(string databaseName, string collectionName);

		Task<List<TodoItem>> GetTodoItemsAsync();

		Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

		Task DeleteTodoItemAsync(string id);
	}
}
