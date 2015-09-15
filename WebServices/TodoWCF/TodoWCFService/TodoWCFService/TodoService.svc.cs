using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using TodoWCFService.Models;
using TodoWCFService.Services;

namespace TodoWCFService
{
    public class TodoService : ITodoService
    {
        static readonly Services.ITodoService todoService = new Services.TodoService(new TodoRepository());

        public List<TodoItem> GetTodoItems()
        {
            return todoService.GetData().ToList();
        }

        public void CreateTodoItem(TodoItem item)
        {
            try
            {
                if (item == null ||
                    string.IsNullOrWhiteSpace(item.Name) ||
                    string.IsNullOrWhiteSpace(item.Notes))
                {
                    throw new FaultException("TodoItem name and notes fields are required");
                }

                // Determine if the ID already exists
                var itemExists = todoService.DoesItemExist(item.ID);
                if (itemExists)
                {
                    throw new FaultException("TodoItem ID is in use");
                }
                todoService.InsertData(item);
            }
            catch (Exception ex)
            {
                throw new FaultException(string.Format("Error: {0}", ex.Message));
            }
        }

        public void EditTodoItem(TodoItem item)
        {
            try
            {
                if (item == null ||
                    string.IsNullOrWhiteSpace(item.Name) ||
                    string.IsNullOrWhiteSpace(item.Notes))
                {
                    throw new FaultException("TodoItem name and notes fields are required");
                }

                var todoItem = todoService.Find(item.ID);
                if (todoItem != null)
                {
                    todoService.UpdateData(item);
                }
                else
                {
                    throw new FaultException("TodoItem not found");
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(string.Format("Error: {0}", ex.Message));
            }
        }

        public void DeleteTodoItem(string id)
        {
            try
            {
                var todoItem = todoService.Find(id);
                if (todoItem != null)
                {
                    todoService.DeleteData(id);
                }
                else
                {
                    throw new FaultException("TodoItem not found");
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(string.Format("Error: {0}", ex.Message));
            }
        }
    }
}
