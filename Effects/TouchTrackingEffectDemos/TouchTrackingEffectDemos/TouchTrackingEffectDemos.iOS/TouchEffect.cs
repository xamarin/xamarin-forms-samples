using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using CoreGraphics;
using Foundation;
using UIKit;

[assembly: ResolutionGroupName("XamarinDocs")]
[assembly: ExportEffect(typeof(TouchTracking.iOS.TouchEffect), "TouchEffect")]

namespace TouchTracking.iOS
{
    public class TouchEffect : PlatformEffect
    {
        UIView view;
        TouchRecognizer touchRecognizer;

        protected override void OnAttached()
        {
            // Get the iOS UIView corresponding to the Element that the effect is attached to
            view = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the PCL
            TouchTracking.TouchEffect effect = (TouchTracking.TouchEffect)Element.Effects.FirstOrDefault(e => e is TouchTracking.TouchEffect);

            if (effect != null && view != null)
            {
                touchRecognizer = new TouchRecognizer(Element, effect.OnTouchAction);
                view.AddGestureRecognizer(touchRecognizer);
            }
        }

        protected override void OnDetached()
        {
            view.RemoveGestureRecognizer(touchRecognizer);
        }
    }

    class TouchRecognizer : UIGestureRecognizer
    {
        Element element;
        Action<Element, TouchActionEventArgs> onTouchAction;

 //       static int id;
 //       static Dictionary<IntPtr, int> idDictionary = new Dictionary<IntPtr, int>();

        public TouchRecognizer(Element element, Action<Element, TouchActionEventArgs> onTouchAction)
        {
            this.element = element;
            this.onTouchAction = onTouchAction;
        }
                    // touches = touches of interest; evt = all touches of type UITouch
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);


            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                Point point = ConvertToPoint(touch.LocationInView(View));

                // touch.Type = UITouchType.Indirect;
                onTouchAction(element, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Entered, point, true));
                onTouchAction(element, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Pressed, point, true));


                // Save ID in dictionary and increment it.
            //    idDictionary.Add(touch.Handle, id);
          //      id++;
            }

            //    NSSet allTouches = evt.AllTouches;
        }

        

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                onTouchAction(element, new TouchActionEventArgs(touch.Handle.ToInt64(), 
                                                                TouchActionType.Moved,
                                                                ConvertToPoint(touch.LocationInView(View)), 
                                                                true));
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
            //    int id = idDictionary[touch.Handle];
                Point point = ConvertToPoint(touch.LocationInView(View));

                                    // TK: Or should isInContact be false for these?????
                onTouchAction(element, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Released, point, true));
                onTouchAction(element, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Exited, point, true));

            //    idDictionary.Remove(touch.Handle);
            }
        }

        public override void TouchesCancelled(NSSet touches, UIEvent evt)
        {
            base.TouchesCancelled(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
           //     int id = idDictionary[touch.Handle];
                Point point = ConvertToPoint(touch.LocationInView(View));

                onTouchAction(element, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Cancelled, point, true));

            //    idDictionary.Remove(touch.Handle);
            }
        }

        Point ConvertToPoint(CGPoint cgPoint)
        {
            return new Point(cgPoint.X, cgPoint.Y);
        }
    }
}