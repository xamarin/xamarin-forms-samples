using System;
using System.Threading.Tasks;
using Redux;

namespace TodoRedux.Helpers
{
	public delegate Task AsyncActionsCreator<TState>(Dispatcher dispatcher, Func<TState> getState);
	public delegate void ActionsCreator<TState>(Dispatcher dispatcher, Func<TState> getState);

	public static class StoreExtensions
	{
		/// <summary>
		/// Extension on IStore to dispatch multiple actions via a thunk. 
		/// Can be used like https://github.com/gaearon/redux-thunk without the need of middleware.
		/// </summary>
		public static Task DispatchAsync<TState>(this IStore<TState> store, AsyncActionsCreator<TState> actionsCreator)
		{
			return actionsCreator(store.Dispatch, store.GetState);
		}

		public static void Dispatch<TState>(this IStore<TState> store, ActionsCreator<TState> actionsCreator)
		{
			actionsCreator(store.Dispatch, store.GetState);
		}
	}
}
