using System;
using System.Linq;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("XamarinDocs")]
[assembly: ExportEffect(typeof(TouchTracking.UWP.TouchEffect), "TouchEffect")]

namespace TouchTracking.UWP
{
    public class TouchEffect : PlatformEffect
    {
        Action<Element, TouchActionEventArgs> onTouchAction;
        FrameworkElement frameworkElement;

        protected override void OnAttached()
        {
            // Get access to the TouchEffect class in the PCL
            TouchTracking.TouchEffect effect = (TouchTracking.TouchEffect)Element.Effects.FirstOrDefault(e => e is TouchTracking.TouchEffect);
            frameworkElement = Control == null ? Container : Control;

            if (effect != null && frameworkElement != null)
            {
                onTouchAction = effect.OnTouchAction;

                frameworkElement.PointerEntered += OnPointerEntered;
                frameworkElement.PointerPressed += OnPointerPressed;
                frameworkElement.PointerMoved += OnPointerMoved;
                frameworkElement.PointerReleased += OnPointerReleased;
                frameworkElement.PointerExited += OnPointerExited;
            }
        }

        protected override void OnDetached()
        {
            if (onTouchAction != null)
            {
                frameworkElement.PointerEntered -= OnPointerEntered;
                frameworkElement.PointerPressed -= OnPointerPressed;
                frameworkElement.PointerMoved -= OnPointerMoved;
                frameworkElement.PointerReleased -= OnPointerReleased;
                frameworkElement.PointerExited -= OnPointerEntered;
            }
        }

        void OnPointerEntered(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, TouchActionType.Entered, args);
        }

        void OnPointerPressed(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, TouchActionType.Pressed, args);
        }

        void OnPointerMoved(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, TouchActionType.Moved, args);
        }

        void OnPointerReleased(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, TouchActionType.Released, args);
        }

        void OnPointerExited(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, TouchActionType.Exited, args);
        }

        void CommonHandler(object sender, TouchActionType touchActionType, PointerRoutedEventArgs args)
        {
            onTouchAction(Element, new TouchActionEventArgs(args.Pointer.PointerId,
                                                            touchActionType,
                                                            PointerPointToPoint(args.GetCurrentPoint(sender as UIElement)),
                                                            args.Pointer.IsInContact));
        }

        Point PointerPointToPoint(PointerPoint pointerPoint)
        {
            Windows.Foundation.Point winPoint = pointerPoint.Position;
            return new Point(winPoint.X, winPoint.Y);
        }
    }
}
