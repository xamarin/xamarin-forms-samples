using System;
using System.Threading;
using System.Threading.Tasks;

namespace Todo
{
	internal delegate Task TimerCallback(object state);

	internal sealed class Timer : IDisposable
	{
		static Task CompletedTask = Task.FromResult(false);

		TimerCallback callback;
		Task delay;
		bool disposed;
		int period;
		object state;
		CancellationTokenSource tokenSource;

		public Timer(TimerCallback callback, object state, int dueTime, int period)
		{
			this.callback = callback;
			this.state = state;
			this.period = period;
			Reset(dueTime);
		}

		public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
			: this(callback, state, (int)dueTime.TotalMilliseconds, (int)period.TotalMilliseconds)
		{
		}

		~Timer()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		void Dispose(bool cleanUpManagedObjects)
		{
			if (cleanUpManagedObjects)
			{
				Cancel();
			}
			disposed = true;
		}

		public void Change(int dueTime, int period)
		{
			this.period = period;
			Reset(dueTime);
		}

		public void Change(TimeSpan dueTime, TimeSpan period)
		{
			Change((int)dueTime.TotalMilliseconds, (int)period.TotalMilliseconds);
		}

		void Reset(int due)
		{
			Cancel();
			if (due >= 0)
			{
				tokenSource = new CancellationTokenSource();
				Action tick = null;
				tick = () =>
				{
					Task.Run(() => callback(state));
					if (!disposed && period >= 0)
					{
						if (period > 0)
							delay = Task.Delay(period, tokenSource.Token);
						else
							delay.ContinueWith(t => tick(), tokenSource.Token);
					}
					if (due > 0)
						delay = Task.Delay(due, tokenSource.Token);
					else
						delay = CompletedTask;
					delay.ContinueWith(t => tick(), tokenSource.Token);
				};
			}
		}

		void Cancel()
		{
			if (tokenSource != null)
			{
				tokenSource.Cancel();
				tokenSource.Dispose();
				tokenSource = null;
			}
		}
	}
}
