using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace TodoASMX.iOS
{
	public class SoapService : ISoapService
	{
		ASMXService.TodoService todoService;

		public List<TodoItem> Items { get; private set; }

		public SoapService ()
		{
			todoService = new ASMXService.TodoService (Constants.SoapUrl);
		}

		ASMXService.TodoItem ToASMXServiceTodoItem (TodoItem item)
		{
			return new ASMXService.TodoItem {
				ID = item.ID,
				Name = item.Name,
				Notes = item.Notes,
				Done = item.Done
			};
		}

		static TodoItem FromASMXServiceTodoItem (ASMXService.TodoItem item)
		{
			return new TodoItem {
				ID = item.ID,
				Name = item.Name,
				Notes = item.Notes,
				Done = item.Done
			};
		}

		public async Task<List<TodoItem>> RefreshDataAsync ()
		{
			Items = new List<TodoItem> ();

			try {
				var todoItems = await Task.Factory.FromAsync<ASMXService.TodoItem[]> (todoService.BeginGetTodoItems, todoService.EndGetTodoItems, null, TaskCreationOptions.None);

				foreach (var item in todoItems) {
					Items.Add (FromASMXServiceTodoItem (item));
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}

			return Items;
		}

		public async Task SaveTodoItemAsync (TodoItem item, bool isNewItem = false)
		{
			try {
				var todoItem = ToASMXServiceTodoItem (item);
				if (isNewItem) {
					await Task.Factory.FromAsync (todoService.BeginCreateTodoItem, todoService.EndCreateTodoItem, todoItem, TaskCreationOptions.None);
				} else {
					await Task.Factory.FromAsync (todoService.BeginEditTodoItem, todoService.EndEditTodoItem, todoItem, TaskCreationOptions.None);
				}
			} catch (SoapException se) {
				Debug.WriteLine (@"				{0}", se.Message);
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}

		public async Task DeleteTodoItemAsync (string id)
		{
			try {
				await Task.Factory.FromAsync (todoService.BeginDeleteTodoItem, todoService.EndDeleteTodoItem, id, TaskCreationOptions.None);
			} catch (SoapException se) {
				Debug.WriteLine (@"				{0}", se.Message);
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}
	}
}
