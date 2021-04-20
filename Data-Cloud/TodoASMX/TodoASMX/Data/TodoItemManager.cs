using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoASMX
{
	public class TodoItemManager
	{
		ISoapService soapService;

		public TodoItemManager (ISoapService service)
		{
			soapService = service;
		}

		public Task<List<TodoItem>> GetTodoItemsAsync ()
		{
			return soapService.RefreshDataAsync ();
		}

		public Task SaveTodoItemAsync (TodoItem item, bool isNewItem = false)
		{
			return soapService.SaveTodoItemAsync (item, isNewItem);
		}

		public Task DeleteTodoItemAsync (TodoItem item)
		{
			return soapService.DeleteTodoItemAsync (item.ID);
		}
	}
}
