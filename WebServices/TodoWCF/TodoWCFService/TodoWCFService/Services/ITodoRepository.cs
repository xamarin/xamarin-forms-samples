using System.Collections.Generic;
using TodoWCFService.Models;

namespace TodoWCFService.Services
{
    public interface ITodoRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<TodoItem> All { get; }
        TodoItem Find(string id);
        void Insert(TodoItem item);
        void Update(TodoItem item);
        void Delete(string id);
    }
}
