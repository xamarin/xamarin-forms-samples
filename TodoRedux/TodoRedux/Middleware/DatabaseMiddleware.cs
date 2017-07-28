using System;
using LiteDB;
using Redux;
using TodoRedux.Actions;
using TodoRedux.State;

namespace TodoRedux.Middleware
{
    public class DatabaseMiddleware<TState>
    {
        private LiteCollection<TodoItem> _todoCollection;

        public DatabaseMiddleware(String databaseName)
        {
            var db = new LiteDatabase(databaseName);
            _todoCollection = db.GetCollection<TodoItem>("Todos");
        }

        public Middleware<TState> CreateMiddleware()
        {
            return store => next => action =>
            {
                if (action is AddTodoAction)
                {
                    AddAction((AddTodoAction)action);
                }
				if (action is RemoveTodoAction)
				{
					RemoveAction((RemoveTodoAction)action);
				}
				if (action is UpdateTodoAction)
				{
					UpdateAction((UpdateTodoAction)action);
				}
				if (action is FetchTodosAction)
                {
                    FetchTodos((FetchTodosAction)action);
                }
                return next(action);
            };
        }

        private void UpdateAction(UpdateTodoAction action)
        {
			_todoCollection.Update(new TodoItem
			{
				Id = action.Id,
				Text = action.Text
			});
        }

        private void RemoveAction(RemoveTodoAction action)
        {
            _todoCollection.Delete(action.Id);
        }

        private void FetchTodos(FetchTodosAction action)
        {
            action.Todos = _todoCollection.FindAll();
        }

        private void AddAction(AddTodoAction action)
        {
            _todoCollection.Insert(new TodoItem
            {
                Id = action.Id,
                Text = action.Text
            });
        }
    }
}
