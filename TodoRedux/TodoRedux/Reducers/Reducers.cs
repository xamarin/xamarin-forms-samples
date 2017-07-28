using Redux;
using TodoRedux.State;

namespace TodoRedux.Reducers
{
    public class Reducers
    {
		public static ApplicationState ReduceApplication(ApplicationState previousState, IAction action)
		{
			return new ApplicationState
			{
				Todos = TodoReducers.Reduce(previousState.Todos, action)
			};
		}
    }
}
