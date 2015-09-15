using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace AzureTodo
{
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public class TodoItemManager
	{
		// Azure
		IMobileServiceTable<TodoItem> todoTable;

		public TodoItemManager()
		{
			todoTable = App.Client.GetTable<TodoItem> ();
		}

//		public ToDoItem GetTaskFromList(string id)
//		{
//			return todoTable.FirstOrDefault(o => o.ID == id);   
//		}

		public async Task<TodoItem> GetTaskAsync(string id)
		{
			try
			{
				return await todoTable.LookupAsync(id);
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
			return null;
		}

		public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync()
		{
			try
			{
				return new ObservableCollection<TodoItem>(
					await todoTable.Where(todoItem => todoItem.Done == false).ToListAsync());
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
			return null;
		}

		public async Task SaveTaskAsync(TodoItem item)
		{
			if (item.ID == null)
			{
				await todoTable.InsertAsync(item);
				//TodoViewModel.TodoItems.Add(item);
			}
			else
            {
                await todoTable.UpdateAsync(item);
            }
		}

//		public async Task DeleteTaskAsync(TodoItem item)
//		{
//			try
//			{
//				//TodoViewModel.TodoItems.Remove(item);
//				await todoTable.DeleteAsync(item);
//			}
//			catch (MobileServiceInvalidOperationException msioe)
//			{
//				Debug.WriteLine(@"INVALID {0}", msioe.Message);
//			}
//			catch (Exception e)
//			{
//				Debug.WriteLine(@"ERROR {0}", e.Message);
//			}
//		}
	}
}

