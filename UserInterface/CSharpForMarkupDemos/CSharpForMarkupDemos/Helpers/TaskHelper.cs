using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpForMarkupDemos.Helpers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>
	/// Run synchronous and asychronous actions on the UI thread
	/// Run synchronous and asychronous functions on the UI thread and return their result
	/// Optimized: when already on the UI thread, executes directly without any scheduling.
	/// Based on http://stackoverflow.com/questions/15428604/how-to-run-a-task-on-a-custom-taskscheduler-using-await
	/// </summary>
	public static class TaskHelper
	{
		static TaskScheduler uiTaskScheduler;
		static TaskFactory uiTaskFactory;

		/// <summary>
		/// Call this method from the UI thread at application start, before you call RunOnUIThread
		/// </summary>
		public static void InitializeFromUIThread()
		{
			uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
			uiTaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskContinuationOptions.None, uiTaskScheduler);
		}

		public static Task RunOnUIThread(Func<Task> asyncAction) => uiTaskFactory.StartNew(asyncAction).Unwrap();

		public static Task<T> RunOnUIThread<T>(Func<Task<T>> asyncFunction) => uiTaskFactory.StartNew(asyncFunction).Unwrap();

		public static Task RunOnUIThread(Action action)
		{
			// If we are already on the UI thread, execute the action inline.
			if (TaskScheduler.Current?.Id == uiTaskScheduler.Id) // We are already on the UI thread; excecute the action inline
			{
				action();
				return Task.CompletedTask;
			}

			return uiTaskFactory.StartNew(action);
		}

		public static Task<T> RunOnUIThread<T>(Func<T> function)
		{
			// If we are already on the UI thread, execute the function inline.
			if (TaskScheduler.Current?.Id == uiTaskScheduler.Id) // We are already on the UI thread; excecute the action inline
			{
				T result = function();
				return Task.FromResult(result);
			}

			return uiTaskFactory.StartNew(function);
		}
	}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
