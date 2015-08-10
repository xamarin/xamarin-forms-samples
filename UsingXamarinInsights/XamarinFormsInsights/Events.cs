using System;

namespace HoustonForms
{
    public class WorkCompletedEventArgs : EventArgs
    {
        public WorkCompletedEventArgs(string val = "")
        {
            ModuleName = val;
        }

        public readonly string ModuleName;
    }

    public class WorkCompletedEvent
    {
        public event WorkCompletedHandler Change;

        public delegate void WorkCompletedHandler(object s,WorkCompletedEventArgs ea);

        protected void OnChange(object s, WorkCompletedEventArgs e)
        {
            if (Change != null)
                Change(s, e);
        }

        public void BroadcastIt(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var info = new WorkCompletedEventArgs(message);
                OnChange(this, info);
            }
        }
    }
}

