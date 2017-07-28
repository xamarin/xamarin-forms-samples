using System.Collections.Generic;
using Redux;
using TodoRedux.State;

namespace TodoRedux.Actions
{
    public class FetchTodosAction : IAction
    {
        public IEnumerable<TodoItem> Todos { get; internal set; }
    }
}