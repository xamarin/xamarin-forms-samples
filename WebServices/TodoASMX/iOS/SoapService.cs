using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace TodoASMX.iOS
{
	public class SoapService : ISoapService
	{
		ASMXService.TodoService todoService;
        TaskCompletionSource<bool> getRequestComplete = null;
        TaskCompletionSource<bool> saveRequestComplete = null;
        TaskCompletionSource<bool> deleteRequestComplete = null;

        public List<TodoItem> Items { get; private set; }

        public SoapService()
        {
            todoService = new ASMXService.TodoService();
            todoService.Url = Constants.SoapUrl;

            todoService.GetTodoItemsCompleted += TodoService_GetTodoItemsCompleted;
            todoService.CreateTodoItemCompleted += TodoService_SaveTodoItemCompleted;
            todoService.EditTodoItemCompleted += TodoService_SaveTodoItemCompleted;
            todoService.DeleteTodoItemCompleted += TodoService_DeleteTodoItemCompleted;

        }

        ASMXService.TodoItem ToASMXServiceTodoItem(TodoItem item)
        {
            return new ASMXService.TodoItem
            {
                ID = item.ID,
                Name = item.Name,
                Notes = item.Notes,
                Done = item.Done
            };
        }

        static TodoItem FromASMXServiceTodoItem(ASMXService.TodoItem item)
        {
            return new TodoItem
            {
                ID = item.ID,
                Name = item.Name,
                Notes = item.Notes,
                Done = item.Done
            };
        }

        private void TodoService_GetTodoItemsCompleted(object sender, ASMXService.GetTodoItemsCompletedEventArgs e)
        {
            try
            {
                getRequestComplete = getRequestComplete ?? new TaskCompletionSource<bool>();

                Items = new List<TodoItem>();
                foreach (var item in e.Result)
                {
                    Items.Add(FromASMXServiceTodoItem(item));
                }
                getRequestComplete?.TrySetResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        private void TodoService_SaveTodoItemCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            saveRequestComplete?.TrySetResult(true);
        }


        private void TodoService_DeleteTodoItemCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            deleteRequestComplete?.TrySetResult(true);
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            getRequestComplete = new TaskCompletionSource<bool>();
            todoService.GetTodoItemsAsync();
            await getRequestComplete.Task;
            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        {
            try
            {
                var todoItem = ToASMXServiceTodoItem(item);
                saveRequestComplete = new TaskCompletionSource<bool>();
                if (isNewItem)
                {
                    todoService.CreateTodoItemAsync(todoItem);
                }
                else
                {
                    todoService.EditTodoItemAsync(todoItem);
                }
                await saveRequestComplete.Task;
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            try
            {
                deleteRequestComplete = new TaskCompletionSource<bool>();
                todoService.DeleteTodoItemAsync(id);
                await deleteRequestComplete.Task;
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }
    }
}
