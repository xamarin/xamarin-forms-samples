using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading.Tasks;
using TodoWCF.TodoWCFService;

namespace TodoWCF
{
	public class SoapService : ISoapService
	{
		ITodoService todoService;

		public List<TodoItem> Items { get; private set; }

		public SoapService ()
		{
			todoService = new TodoServiceClient (
				new BasicHttpBinding (),
				new EndpointAddress (Constants.SoapUrl));
		}

		TodoWCFService.TodoItem ToWCFServiceTodoItem (TodoItem item)
		{
			return new TodoWCFService.TodoItem {
				ID = item.ID,
				Name = item.Name,
				Notes = item.Notes,
				Done = item.Done
			};
		}

		static TodoItem FromWCFServiceTodoItem (TodoWCFService.TodoItem item)
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
				var todoItems = await Task.Factory.FromAsync <ObservableCollection<TodoWCFService.TodoItem>> (todoService.BeginGetTodoItems, todoService.EndGetTodoItems, null, TaskCreationOptions.None);

				foreach (var item in todoItems) {
					Items.Add (FromWCFServiceTodoItem (item));
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}

			return Items;
		}

		public async Task SaveTodoItemAsync (TodoItem item, bool isNewItem = false)
		{
			try {
				var todoItem = ToWCFServiceTodoItem (item);
				if (isNewItem) {
					await Task.Factory.FromAsync (todoService.BeginCreateTodoItem, todoService.EndCreateTodoItem, todoItem, TaskCreationOptions.None);
				} else {
					await Task.Factory.FromAsync (todoService.BeginEditTodoItem, todoService.EndEditTodoItem, todoItem, TaskCreationOptions.None);
				}
			} catch (FaultException fe) {
				Debug.WriteLine (@"			{0}", fe.Message);
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}

		public async Task DeleteTodoItemAsync (string id)
		{
			try {
				await Task.Factory.FromAsync (todoService.BeginDeleteTodoItem, todoService.EndDeleteTodoItem, id, TaskCreationOptions.None);
			} catch (FaultException fe) {
				Debug.WriteLine (@"			{0}", fe.Message);
			} catch (Exception ex) {
				Debug.WriteLine (@"				ERROR {0}", ex.Message);
			}
		}
	}
}
