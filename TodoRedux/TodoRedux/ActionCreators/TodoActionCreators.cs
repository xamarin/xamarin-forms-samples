using System;
using Redux;
using TodoRedux.Actions;

namespace TodoRedux.ActionCreators
{
    public class TodoActionCreators
    {
		public static IAction AddTodo(Guid id, string text)
		{
			return new AddTodoAction()
			{
				Id = id,
				Text = text
			};
		}

		public static IAction UpdateTodo(Guid id, string text)
		{
			return new UpdateTodoAction()
			{
				Id = id,
				Text = text
			};
		}

		public static IAction RemoveTodo(Guid id)
		{
			return new RemoveTodoAction()
			{
				Id = id
			};
		}

        public static IAction FetchAll()
        {
            return new FetchTodosAction();
        }
    }
}
