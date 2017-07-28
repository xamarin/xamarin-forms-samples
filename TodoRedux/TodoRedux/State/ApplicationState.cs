using System.Collections.Immutable;

namespace TodoRedux.State
{
    public class ApplicationState
    {
        public ImmutableArray<TodoItem> Todos { get; set; }

        public ApplicationState()
        {
            Todos = ImmutableArray<TodoItem>.Empty;
        }
    }
}
