using System;

namespace CSharpForMarkupDemos.Helpers
{
    public class SingleSubscriptionEnsurer<T> where T : class
    {
        readonly Action<T> subscribe, unsubscribe;
        T subscribedSender;

        public SingleSubscriptionEnsurer(Action<T> subscribe, Action<T> unsubscribe)
        {
            this.subscribe = subscribe;
            this.unsubscribe = unsubscribe;
        }

        public void EnsureSubscribed(T sender)
        {
            if (!object.ReferenceEquals(subscribedSender, sender))
            {
                EnsureUnsubscribed();
                if (sender != null)
                {
                    subscribe.Invoke(sender);
                    subscribedSender = sender;
                }
            }
        }

        public void EnsureUnsubscribed()
        {
            if (subscribedSender != null)
            {
                unsubscribe.Invoke(subscribedSender);
                subscribedSender = null;
            }
        }
    }
}
