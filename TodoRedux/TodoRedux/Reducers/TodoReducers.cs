using System;
using System.Collections.Immutable;
using System.Linq;
using Redux;
using TodoRedux.Actions;
using TodoRedux.State;

namespace TodoRedux.Reducers
{
    public class TodoReducers
    {
		public static ImmutableArray<TodoItem> Reduce(ImmutableArray<TodoItem> previousState, IAction action)
		{
			if (action is AddTodoAction)
			{
				return AddTodoReducer(previousState, (AddTodoAction)action);
			}
			if (action is UpdateTodoAction)
			{
				return UpdateTodoReducer(previousState, (UpdateTodoAction)action);
			}
            if (action is RemoveTodoAction)
            {
                return RemoveTodoReducer(previousState, (RemoveTodoAction)action);
            }
            if (action is FetchTodosAction)
            {
                return FetchTodosReducer(previousState, (FetchTodosAction)action);
            }

			return previousState;
		}

        private static ImmutableArray<TodoItem> FetchTodosReducer(ImmutableArray<TodoItem> previousState, FetchTodosAction action)
        {
            return ImmutableArray.CreateRange(action.Todos);
        }

        private static ImmutableArray<TodoItem> UpdateTodoReducer(ImmutableArray<TodoItem> previousState, UpdateTodoAction action)
		{
			return previousState
				.Select(x =>
				{
					if (x.Id == action.Id)
					{
						return new TodoItem()
						{
							Id = action.Id,
							Text = action.Text
						};
					}
					return x;
				})
				.ToImmutableArray();
		}

        private static ImmutableArray<TodoItem> RemoveTodoReducer(ImmutableArray<TodoItem> previousState, RemoveTodoAction action)
        {
            var todoToDelete = previousState.First(todo => todo.Id == action.Id);
			return previousState.Remove(todoToDelete);
        }

        private static ImmutableArray<TodoItem> AddTodoReducer(ImmutableArray<TodoItem> previousState, AddTodoAction action)
        {
			return previousState
				.Insert(0, new TodoItem
				{
					Id = action.Id,
					Text = action.Text
				});
        }
    }
}
