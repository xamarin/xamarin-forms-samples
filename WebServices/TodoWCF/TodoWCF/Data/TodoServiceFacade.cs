using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWCF.TodoWCFService;
using System.Linq;
using System.Collections.ObjectModel;

namespace TodoWCF
{
	public class TodoServiceFacade : ITodoServiceFacade
	{
		ITodoService todoService;

		public TodoServiceFacade (ITodoService service)
		{
			todoService = service;
		}

		public async Task<List<TodoItem>> GetTodoItemsAsync ()
		{
			Task<ObservableCollection<TodoWCFService.TodoItem>> task = new TaskFactory ().FromAsync (todoService.BeginGetTodoItems, todoService.EndGetTodoItems, null);
			var result = await task;
			resul
			var list = new List<TodoItem> (result);

			return null;
			//return await task;
		}
	}
}

