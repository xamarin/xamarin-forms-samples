using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TodoASMX.UWP
{
    public class SoapService : ISoapService
    {
        ASMXService.TodoASMXServiceSoapClient todoService;

        public List<TodoItem> Items { get; private set; }

        public SoapService()
        {
            todoService = new ASMXService.TodoASMXServiceSoapClient();
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

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            Items = new List<TodoItem>();

            try
            {
                var response = await todoService.GetTodoItemsAsync();
                var todoItems = response.Body.GetTodoItemsResult;
                
                foreach (var item in todoItems)
                {
                    Items.Add(FromASMXServiceTodoItem(item));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
        {
            try
            {
                var todoItem = ToASMXServiceTodoItem(item);
                if (isNewItem)
                {
                    await todoService.CreateTodoItemAsync(todoItem);
                }
                else
                {
                    await todoService.EditTodoItemAsync(todoItem);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            try
            {
                await todoService.DeleteTodoItemAsync(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }
    }
}
