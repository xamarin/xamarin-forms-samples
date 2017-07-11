using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TouchTracking;

namespace TouchTrackingEffectDemos
{
    class Key : BoxView
    {
        List<long> ids = new List<long>();

        public event EventHandler StatusChanged;

        public Key()
        {
            TouchEffect effect = new TouchEffect();
            effect.TouchAction += OnTouchEffectAction;
            Effects.Add(effect);
        }

        public int KeyNumber { set; get; }

        public bool IsPressed { private set; get; }

        protected Color UpColor { set; get; }

        protected Color DownColor { set; get; }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    AddToList(args.Id);
                    break;

                case TouchActionType.Entered:
                    if (args.IsInContact)
                    {
                        AddToList(args.Id);
                    }
                    break;

                case TouchActionType.Moved:
                    break;

                case TouchActionType.Released:
                case TouchActionType.Exited:
                    RemoveFromList(args.Id);
                    break;
            }
        }

        void AddToList(long id)
        {
            if (!ids.Contains(id))
            {
                ids.Add(id);
            }

            CheckList();
        }

        void RemoveFromList(long id)
        {
            if (ids.Contains(id))
            {
                ids.Remove(id);
            }

            CheckList();
        }

        void CheckList()
        {
            if (IsPressed != ids.Count > 0)
            {
                IsPressed = ids.Count > 0;
                Color = IsPressed ? DownColor : UpColor;
                StatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
