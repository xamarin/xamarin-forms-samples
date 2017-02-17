using System;
using System.Collections.Generic;

using Xamarin.Forms;

using TouchTracking;

namespace TouchTrackingEffectDemos
{
    public partial class BoxViewDraggingPage : ContentPage
    {
        Random random = new Random();
        Dictionary<long, Point> dragDictionary = new Dictionary<long, Point>();

        public BoxViewDraggingPage()
        {
            InitializeComponent();
        }

        void OnNewBoxViewClicked(object sender, EventArgs args)
        {
            AddBoxViewToLayout();
        }

        void OnClearClicked(object sender, EventArgs args)
        {
            absoluteLayout.Children.Clear();
        }

        void AddBoxViewToLayout()
        {
            BoxView boxView = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Color = new Color(random.NextDouble(),
                                  random.NextDouble(),
                                  random.NextDouble())
            };

            TouchEffect touchEffect = new TouchEffect();
            touchEffect.TouchAction += OnTouchEffectAction;
            boxView.Effects.Add(touchEffect);

            absoluteLayout.Children.Add(boxView);
        }
        
        private void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            BoxView boxView = sender as BoxView;
            TouchEffect touchEffect = boxView.Effects[0] as TouchEffect;

            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (args.IsInContact && !dragDictionary.ContainsKey(args.Id))
                    {
                        System.Diagnostics.Debug.WriteLine("Pressed: " + args.Location);


                        dragDictionary.Add(args.Id, args.Location);
                        touchEffect.Capture = true;
                    }
                    break;

                case TouchActionType.Moved:
                    if (dragDictionary.ContainsKey(args.Id))
                    {
                        System.Diagnostics.Debug.WriteLine("Moved: " + args.Location);


                        Rectangle rect = AbsoluteLayout.GetLayoutBounds(boxView);
                        Point initialLocation = dragDictionary[args.Id];
                        rect.X += args.Location.X - initialLocation.X;
                        rect.Y += args.Location.Y - initialLocation.Y;
                        AbsoluteLayout.SetLayoutBounds(boxView, rect);
                    }
                    break;

                case TouchActionType.Released:
                    if (dragDictionary.ContainsKey(args.Id))
                    {
                        dragDictionary.Remove(args.Id);
                    }
                    break;
            }
        }
    }
}
