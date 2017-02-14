using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using CoreGraphics;
using Foundation;
using UIKit;

namespace TouchTracking.iOS
{
    class TouchRecognizer : UIGestureRecognizer
    {
        Element formsElement;
        UIView uiView;
        TouchTracking.TouchEffect touchEffect;
        Action<Element, TouchActionEventArgs> onTouchAction;
        bool capture;

        static Dictionary<UIView, TouchRecognizer> viewDictionary = new Dictionary<UIView, TouchRecognizer>();

        static Dictionary<long, TouchRecognizer> idToTouchDictionary = new Dictionary<long, TouchRecognizer>();

        public TouchRecognizer(Element element, UIView view, TouchTracking.TouchEffect touchEffect)
        {
            this.formsElement = element;
            this.uiView = view;
            this.touchEffect = touchEffect;
            onTouchAction = touchEffect.OnTouchAction;

            viewDictionary.Add(uiView, this);
        }

        public void Detach()
        {
            viewDictionary.Remove(uiView);
        }

        // touches = touches of interest; evt = all touches of type UITouch
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                long id = touch.Handle.ToInt64();
                Point point = ConvertToPoint(touch.LocationInView(View));

                // touch.Type = UITouchType.Indirect;
                onTouchAction(formsElement, 
                    new TouchActionEventArgs(id, TouchActionType.Pressed, point, true));

                idToTouchDictionary.Add(id, this);
            }

            // Save the setting of the Capture property
            capture = touchEffect.Capture;
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            foreach (UITouch touch in touches.Cast<UITouch>())
            {
                long id = touch.Handle.ToInt64();

                if (capture)
                {
                    onTouchAction(formsElement, new TouchActionEventArgs(id,
                                                                         TouchActionType.Moved,
                                                                         ConvertToPoint(touch.LocationInView(View)),
                                                                         true));
                }
                else
                {

                    /*
                                   //     void CheckForBoundaryHop(UITouch touch)

                                        // TODO: Might require converting to a List for multiple hits
                                        TouchRecognizer recognizerHit = null;

                                        foreach (UIView view in viewDictionary.Keys)
                                        {
                                            CGPoint location = touch.LocationInView(view);

                                            if (new CGRect(new CGPoint(), view.Frame.Size).Contains(location))
                                            {
                                                recognizerHit = viewDictionary[view];
                                            }
                                        }

                                        if (recognizerHit != idToTouchDictionary[id])
                                        {
                                            if (idToTouchDictionary[id] != null)
                                            {
                                                FireEvent(idToTouchDictionary[id], id, TouchActionType.Exited, touch);
                                            }

                                            if (recognizerHit != null)
                                            {
                                                FireEvent(recognizerHit, id, TouchActionType.Entered, touch);
                                            }

                                            idToTouchDictionary[id] = recognizerHit;
                                        }

                        */

                    CheckForBoundaryHop(touch);




                    if (idToTouchDictionary[id] != null) // recognizerHit != null)      // or idToTouchDictionary[id] to move stuff to other method
                    {
                        FireEvent(idToTouchDictionary[id] /* recognizerHit */ , id, TouchActionType.Moved, touch);
                    }
                }
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
                onTouchAction(formsElement, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Released, point, true));
            //    onTouchAction(formsElement, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Exited, point, true));

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

                onTouchAction(formsElement, new TouchActionEventArgs(touch.Handle.ToInt64(), TouchActionType.Cancelled, point, true));

                //    idDictionary.Remove(touch.Handle);
            }
        }


        void CheckForBoundaryHop(UITouch touch)
        {
            long id = touch.Handle.ToInt64();

            // TODO: Might require converting to a List for multiple hits
            TouchRecognizer recognizerHit = null;

            foreach (UIView view in viewDictionary.Keys)
            {
                CGPoint location = touch.LocationInView(view);

                if (new CGRect(new CGPoint(), view.Frame.Size).Contains(location))
                {
                    recognizerHit = viewDictionary[view];
                }
            }

            if (recognizerHit != idToTouchDictionary[id])
            {
                if (idToTouchDictionary[id] != null)
                {
                    FireEvent(idToTouchDictionary[id], id, TouchActionType.Exited, touch);
                }

                if (recognizerHit != null)
                {
                    FireEvent(recognizerHit, id, TouchActionType.Entered, touch);
                }

                idToTouchDictionary[id] = recognizerHit;
            }
        }






        void FireEvent(TouchRecognizer recognizer, long id, TouchActionType actionType, UITouch touch)
        {
            Element formsElement = recognizer.formsElement;
            CGPoint location = touch.LocationInView(recognizer.uiView);

            recognizer.onTouchAction(recognizer.formsElement,
                new TouchActionEventArgs(id, actionType, ConvertToPoint(location), true));
        }

        Point ConvertToPoint(CGPoint cgPoint)
        {
            return new Point(cgPoint.X, cgPoint.Y);
        }
    }
}