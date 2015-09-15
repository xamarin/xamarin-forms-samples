using System.Collections.Generic;
using TodoWCFService.Models;
using System;

namespace TodoWCFService.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public bool DoesItemExist(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(id);
            }

            return _repository.DoesItemExist(id);
        }

        public TodoItem Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            return _repository.Find(id);
        }

        public IEnumerable<TodoItem> GetData()
        {
            return _repository.All;
        }

        public void InsertData(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _repository.Insert(item);
        }

        public void UpdateData(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _repository.Update(item);
        }

        public void DeleteData(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            _repository.Delete(id);
        }
    }
}
