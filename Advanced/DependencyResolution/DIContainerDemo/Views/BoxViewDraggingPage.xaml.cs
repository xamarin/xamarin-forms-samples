using System;
using System.Collections.Generic;
using System.Linq;
using TouchTracking;
using Xamarin.Forms;

namespace DIContainerDemo
{
    public partial class BoxViewDraggingPage : ContentPage
    {
        Dictionary<BoxView, DragInfo> _dragDictionary = new Dictionary<BoxView, DragInfo>();
        Random _random = new Random();

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
            _dragDictionary.Clear();
        }

        void AddBoxViewToLayout()
        {
            BoxView boxView = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Color = new Color(_random.NextDouble(),
                                  _random.NextDouble(),
                                  _random.NextDouble())
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
                    if (!_dragDictionary.ContainsKey(boxView))
                    {
                        _dragDictionary.Add(boxView, new DragInfo(args.Id, args.Location));

                        // Set Capture property to true
                        TouchEffect touchEffect = (TouchEffect)boxView.Effects.FirstOrDefault(e => e is TouchEffect);
                        touchEffect.Capture = true;
                    }
                    break;

                case TouchActionType.Moved:
                    if (_dragDictionary.ContainsKey(boxView) && _dragDictionary[boxView].Id == args.Id)
                    {
                        Rectangle rect = AbsoluteLayout.GetLayoutBounds(boxView);
                        Point initialLocation = _dragDictionary[boxView].PressPoint;
                        rect.X += args.Location.X - initialLocation.X;
                        rect.Y += args.Location.Y - initialLocation.Y;
                        AbsoluteLayout.SetLayoutBounds(boxView, rect);
                    }
                    break;

                case TouchActionType.Released:
                    if (_dragDictionary.ContainsKey(boxView) && _dragDictionary[boxView].Id == args.Id)
                    {
                        _dragDictionary.Remove(boxView);
                    }
                    break;
            }
        }
    }
}
