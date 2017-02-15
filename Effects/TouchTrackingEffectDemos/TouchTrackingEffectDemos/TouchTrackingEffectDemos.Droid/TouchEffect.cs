using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Android.Views;

[assembly: ResolutionGroupName("XamarinDocs")]
[assembly: ExportEffect(typeof(TouchTracking.Droid.TouchEffect), "TouchEffect")]

namespace TouchTracking.Droid
{
    public class TouchEffect : PlatformEffect
    {
        Android.Views.View view;
        Element formsElement;
        TouchTracking.TouchEffect touchEffect;
   //     Action<Element, TouchActionEventArgs> onTouchAction;
        bool capture;
        Func<double, double> fromPixels;

        // Information retained for all elements that attach this effect
        class TouchInfo
        {
            public TouchInfo(Element formsElement, Android.Views.View androidView, Action<Element, TouchActionEventArgs> onTouchAction)
            {
                FormsElement = formsElement;
                AndroidView = androidView;
                OnTouchAction = onTouchAction;
            }

            public Element FormsElement { private set; get; }

            public Android.Views.View AndroidView { private set; get; }

            public Action<Element, TouchActionEventArgs> OnTouchAction { private set; get; }
        };

        // 
        static Dictionary<Android.Views.View, TouchInfo> xviewDictionary = new Dictionary<Android.Views.View, TouchInfo>();

        static Dictionary<int, TouchInfo> xidToInfoDictionary = new Dictionary<int, TouchInfo>();

        static Dictionary<Android.Views.View, TouchEffect> viewDictionary = new Dictionary<Android.Views.View, TouchEffect>();

        static Dictionary<int, TouchEffect> idToEffectDictionary = new Dictionary<int, TouchEffect>();

        protected override void OnAttached()
        {
            // Get the Android View corresponding to the Element that the effect is attached to
            view = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the PCL -- can save directly to field
            TouchTracking.TouchEffect touchEffect = 
                (TouchTracking.TouchEffect)Element.Effects.
                    FirstOrDefault(e => e is TouchTracking.TouchEffect);

            if (touchEffect != null && view != null)
            {
                xviewDictionary.Add(view, new TouchInfo(Element, view, touchEffect.OnTouchAction));

                formsElement = Element;

                this.touchEffect = touchEffect;

            //    onTouchAction = touchEffect.OnTouchAction

                // Save fromPixels function
                fromPixels = view.Context.FromPixels;

                // Set event handler on View
                view.Touch += OnTouch;
            }
        }

        protected override void OnDetached()
        {
            if (xviewDictionary.ContainsKey(view))
            {
                xviewDictionary.Remove(view);
                view.Touch -= OnTouch;
            }
        }

        void OnTouch(object sender, Android.Views.View.TouchEventArgs args)
        {
            // Two object common to all the events
            Android.Views.View senderView = sender as Android.Views.View;
            MotionEvent motionEvent = args.Event;

            // Get the pointer index
            int pointerIndex = motionEvent.ActionIndex;

            // Get the id that identifies a finger over the course of its progress
            int id = motionEvent.GetPointerId(pointerIndex);

            // Get the TouchInfo for this View
            TouchInfo touchInfo = xviewDictionary[senderView];


            // Not needed: This is the touchEffect saved as a field!
        //    TouchEffect touchEffect = viewDictionary[senderView];



            // Convert the point to device-independent coordinates
            Point point = new Point(fromPixels(motionEvent.GetX(pointerIndex)),
                                    fromPixels(motionEvent.GetY(pointerIndex)));

            // Use ActionMasked here rather than Action to reduce the number of possibilities
            switch (args.Event.ActionMasked)
            {
                case MotionEventActions.Down:
                case MotionEventActions.PointerDown:
                    // Trigger the Pressed events
        //            touchInfo.OnTouchAction(touchInfo.FormsElement, 
        //                new TouchActionEventArgs(id, TouchActionType.Pressed, point, true));

                    touchEffect.OnTouchAction(formsElement,
                        new TouchActionEventArgs(id, TouchActionType.Pressed, point, true));


                    // Add the TouchInfo to the idToInfoDictonary
                    xidToInfoDictionary.Add(id, touchInfo);

                    idToEffectDictionary.Add(id, this);

                    // Get access to the TouchEffect class in the PCL
        //            TouchTracking.TouchEffect touchEffect = 
           //             (TouchTracking.TouchEffect)Element.Effects.
            //                FirstOrDefault(e => e is TouchTracking.TouchEffect);

                    // Get the Capture property setting from the effect
                    capture = touchEffect.Capture;
                    break;

                case MotionEventActions.Move:
                    // Multiple Move events are bundled, so handle them in a loop
                    for (pointerIndex = 0; pointerIndex < motionEvent.PointerCount; pointerIndex++)
                    {
                        id = motionEvent.GetPointerId(pointerIndex);

                        if (capture)
                        {
                            point = new Point(fromPixels(motionEvent.GetX(pointerIndex)),
                                              fromPixels(motionEvent.GetY(pointerIndex)));

                            touchInfo.OnTouchAction(touchInfo.FormsElement, 
                                new TouchActionEventArgs(id, TouchActionType.Moved, point, true));
                        }
                        else
                        {
                            touchInfo = GetTouchInfoUnderPointer(senderView, motionEvent, pointerIndex, out point);

                            if (touchInfo != null)
                            {
                                touchInfo.OnTouchAction(touchInfo.FormsElement,
                                    new TouchActionEventArgs(id, TouchActionType.Moved, point, true));
                            }
                        }
                    }
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Pointer1Up:
                    if (capture)
                    {
                        touchInfo.OnTouchAction(touchInfo.FormsElement, 
                            new TouchActionEventArgs(id, TouchActionType.Released, point, true));
                    }
                    else
                    {
                        touchInfo = GetTouchInfoUnderPointer(senderView, motionEvent, pointerIndex, out point);

                        if (touchInfo != null)
                        {
                            touchInfo.OnTouchAction(touchInfo.FormsElement, 
                                new TouchActionEventArgs(id, TouchActionType.Released, point, true));
                        }
                    }
                    xidToInfoDictionary.Remove(id);
                    idToEffectDictionary.Remove(id);
                    break;

                case MotionEventActions.Cancel:
                    if (capture)
                    {
                        touchInfo.OnTouchAction(touchInfo.FormsElement, 
                            new TouchActionEventArgs(id, TouchActionType.Cancelled, point, true));
                    }
                    else
                    {
                        if (xidToInfoDictionary[id] != null)
                        {
                            // TODO: Need to convert point!

                            // TODO: Is this right?

                            touchInfo = xidToInfoDictionary[id];
                            touchInfo.OnTouchAction(touchInfo.FormsElement, 
                                new TouchActionEventArgs(id, TouchActionType.Cancelled, point, true));
                        }
                    }
                    xidToInfoDictionary.Remove(id);
                    idToEffectDictionary.Remove(id);
                    break;
            }
        }

        TouchInfo GetTouchInfoUnderPointer(Android.Views.View senderView, MotionEvent motionEvent, int pointerIndex, out Point point)
        {
            // Get the screen location (in pixels) of the Android View generating this event
            int[] screenLocation = new int[2];
            senderView.GetLocationOnScreen(screenLocation);

            // Get the pixel coordinates of the finger relative to the screen
            Point fingerScreenCoordinates = new Point(screenLocation[0] + motionEvent.GetX(pointerIndex),
                                                      screenLocation[1] + motionEvent.GetY(pointerIndex));

//            System.Diagnostics.Debug.WriteLine("finger: {0} {1}", fingerScreenCoordinates.X, fingerScreenCoordinates.Y);


            Android.Views.View viewUnderPointer = null;

            // TODO: Need to replace this...
            TouchInfo touchInfoOver = null;

            // ... with this, and then determine which one is one top
            List<TouchInfo> touchInfosOver = new List<TouchInfo>();

            // Or, does is last one always on top because they're in creation order?


            // Enumerate Android Views with this effect attached
            foreach (Android.Views.View view in xviewDictionary.Keys)
            {
                // Get pixel screen location of this view (use array created earlier)
                try
                {
                    view.GetLocationOnScreen(screenLocation);
                }
                catch // System.ObjectDisposedException: Cannot access a disposed object.
                {
                    continue;
                }
                
                Rectangle viewRect = new Rectangle(screenLocation[0], screenLocation[1], view.Width, view.Height);

//                System.Diagnostics.Debug.WriteLine("view: {0} {1} {2} {3}", viewRect.X, viewRect.Y, view.Width, view.Height);

                // Determine if the pointer is over this view
                if (viewRect.Contains(fingerScreenCoordinates))
                {
                    viewUnderPointer = view;

                    if (xviewDictionary.ContainsKey(viewUnderPointer))
                    {
                        touchInfoOver = xviewDictionary[viewUnderPointer];
                        touchInfosOver.Add(touchInfoOver);
                    }
                }
            }


            // Switch touch event ids from one element to another.
            // Either element could be null

            int id = motionEvent.GetPointerId(pointerIndex);


            if (touchInfoOver != xidToInfoDictionary[id])
            {
                if (xidToInfoDictionary[id] != null)
                {
                    // TODO: Exited point is (0, 0) if moving outside View
                    // ---------------------------------------------------
                    // Need to get Point in relative to idToInfoDictionary[id]

                    Point pt = GetViewRelativePoint(xidToInfoDictionary[id].AndroidView, fingerScreenCoordinates);

                    xidToInfoDictionary[id].OnTouchAction(xidToInfoDictionary[id].FormsElement,
                        new TouchActionEventArgs(id, TouchActionType.Exited, pt, true));
                }

                if (touchInfoOver != null)
                {
                    Point pt = GetViewRelativePoint(touchInfoOver.AndroidView, fingerScreenCoordinates);

                    touchInfoOver.OnTouchAction(touchInfoOver.FormsElement,
                        new TouchActionEventArgs(id, TouchActionType.Entered, pt, true));
                }

                // Save the new elementOver in the dictionary
                xidToInfoDictionary[id] = touchInfoOver;
            }


            // Set the Point passed as a ref 
            point = new Point();

            if (viewUnderPointer != null)           // Change this to touchInfoOver, but renamed.
            {
                point = GetViewRelativePoint(viewUnderPointer, fingerScreenCoordinates);
            }

            return touchInfoOver;
        }

        Point GetViewRelativePoint(Android.Views.View view, Point pixelCoordinates)
        {
            int[] screenLocation = new int[2];
            view.GetLocationOnScreen(screenLocation);
            double x = fromPixels(pixelCoordinates.X - screenLocation[0]);
            double y = fromPixels(pixelCoordinates.Y - screenLocation[1]);
            return new Point(x, y);
        }
    }
}
