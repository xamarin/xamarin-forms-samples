using System;
using System.Collections.Generic;
using TouchTracking;
using Xamarin.Forms;

namespace TouchTrackingEffectDemos
{

    // public temporarily


    public class Key : BoxView
    {
        List<long> ids = new List<long>();

        public event EventHandler Status;

        public Key()
        {
            TouchEffect effect = new TouchEffect(); // OR: TouchEffect effect = Effect.Resolve("XamarinDocs.TouchEffect") as TouchEffect;
            
            effect.TouchAction += OnTouchAction;

            Effects.Add(effect);
        }

        public int KeyNumber { set; get; }

        public bool IsPressed { private set; get; }

        protected Color UpColor { set; get; }

        protected Color DownColor { set; get; }

        void OnTouchAction(object sender, TouchActionEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Key {0} {1} {2}", KeyNumber, args.Type, args.Id);

            switch (args.Type)
            {
                case TouchActionType.Entered:
                    if (args.IsInContact)
                    {
                        AddToList(args.Id);
                    }
                    break;

                case TouchActionType.Pressed:
                    AddToList(args.Id);
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
            IsPressed = ids.Count > 0;
            Color = IsPressed ? DownColor : UpColor;
            Status?.Invoke(this, EventArgs.Empty);
        }
    }
}
