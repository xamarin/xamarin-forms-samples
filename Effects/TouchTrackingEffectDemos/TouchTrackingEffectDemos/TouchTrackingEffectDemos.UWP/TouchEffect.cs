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
        FrameworkElement frameworkElement;
        Action<Element, TouchActionEventArgs> onTouchAction;
        bool capture;

        protected override void OnAttached()
        {
            // Get the Windows FrameworkElement corresponding to the Element that the effect is attached to
            frameworkElement = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the PCL
            TouchTracking.TouchEffect effect = (TouchTracking.TouchEffect)Element.Effects.FirstOrDefault(e => e is TouchTracking.TouchEffect);

            if (effect != null && frameworkElement != null)
            {
                // Save the method to call on touch events
                onTouchAction = effect.OnTouchAction;

                // Save setting of Capture property
                capture = effect.Capture;

                // Set event handlers on FrameworkElement
                frameworkElement.PointerEntered += OnPointerEntered;
                frameworkElement.PointerPressed += OnPointerPressed;
                frameworkElement.PointerMoved += OnPointerMoved;
                frameworkElement.PointerReleased += OnPointerReleased;
                frameworkElement.PointerExited += OnPointerExited;

                // TODO

            //    frameworkElement.PointerCanceled
            }
        }

        protected override void OnDetached()
        {
            if (onTouchAction != null)
            {
                // Release event handlers on FrameworkElement
                frameworkElement.PointerEntered -= OnPointerEntered;
                frameworkElement.PointerPressed -= OnPointerPressed;
                frameworkElement.PointerMoved -= OnPointerMoved;
                frameworkElement.PointerReleased -= OnPointerReleased;
                frameworkElement.PointerExited -= OnPointerEntered;

                // TODO

     //           frameworkElement.PointerCanceled
            }
        }

        void OnPointerEntered(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, TouchActionType.Entered, args);
        }

        void OnPointerPressed(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, TouchActionType.Pressed, args);

            if (capture)
            {
                (sender as FrameworkElement).CapturePointer(args.Pointer);
            }
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
            PointerPoint pointerPoint = args.GetCurrentPoint(sender as UIElement);
            Windows.Foundation.Point windowsPoint = pointerPoint.Position;  

            onTouchAction(Element, new TouchActionEventArgs(args.Pointer.PointerId,
                                                            touchActionType,
                                                            new Point(windowsPoint.X, windowsPoint.Y),
                                                            args.Pointer.IsInContact));
        }
    }
}
