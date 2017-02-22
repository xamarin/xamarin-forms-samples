using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using TouchTracking;

namespace TouchTrackingEffectDemos
{
    public partial class BoxViewDraggingPage : ContentPage
    {
        class DragInfo
        {
            public DragInfo(long id, Point pressPoint)
            {
                Id = id;
                PressPoint = pressPoint;
            }

            public long Id { private set; get; }

            public Point PressPoint { private set; get; }
        }

        Dictionary<BoxView, DragInfo> dragDictionary = new Dictionary<BoxView, DragInfo>();
        Random random = new Random();

        public BoxViewDraggingPage()
        {
            InitializeComponent();
            AddBoxViewToLayout();
        }

        void OnNewBoxViewClicked(object sender, EventArgs args)
        {
            AddBoxViewToLayout();
        }

        void OnClearClicked(object sender, EventArgs args)
        {
            absoluteLayout.Children.Clear();
            dragDictionary.Clear();
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
        
        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            BoxView boxView = sender as BoxView;

            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    // Don't allow a second touch on an already touched BoxView
                    if (!dragDictionary.ContainsKey(boxView))
                    {
                        dragDictionary.Add(boxView, new DragInfo(args.Id, args.Location));

                        // Set Capture property to true
                        TouchEffect touchEffect = (TouchEffect)boxView.Effects.FirstOrDefault(e => e is TouchEffect);
                        touchEffect.Capture = true;
                    }
                    break;

                case TouchActionType.Moved:
                    if (dragDictionary.ContainsKey(boxView) && dragDictionary[boxView].Id == args.Id)
                    {
                        Rectangle rect = AbsoluteLayout.GetLayoutBounds(boxView);
                        Point initialLocation = dragDictionary[boxView].PressPoint;
                        rect.X += args.Location.X - initialLocation.X;
                        rect.Y += args.Location.Y - initialLocation.Y;
                        AbsoluteLayout.SetLayoutBounds(boxView, rect);
                    }
                    break;

                case TouchActionType.Released:
                    if (dragDictionary.ContainsKey(boxView) && dragDictionary[boxView].Id == args.Id)
                    {
                        dragDictionary.Remove(boxView);
                    }
                    break;
            }
        }
    }
}
