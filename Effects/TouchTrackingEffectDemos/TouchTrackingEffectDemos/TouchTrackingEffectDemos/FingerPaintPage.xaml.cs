using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

using TouchTracking;

namespace TouchTrackingEffectDemos
{
    public partial class FingerPaintPage : ContentPage
    {
        Dictionary<long, FingerPaintInfo> linesInProgress = new Dictionary<long, FingerPaintInfo>();
        Color strokeColor = Color.Red;
        double strokeThickness = 1;

        public FingerPaintPage()
        {
            InitializeComponent();
        }

        void OnColorPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            Picker picker = sender as Picker;

            if (picker.SelectedIndex != -1)
            {
                string strColor = picker.Items[picker.SelectedIndex];
                strokeColor = (Color)typeof(Color).GetRuntimeField(strColor).GetValue(null);
            }
        }

        void OnThicknessPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            Picker picker = sender as Picker;

            if (picker.SelectedIndex != -1)
            {
                strokeThickness = new double[] { 1, 2, 5, 10, 20 }[picker.SelectedIndex];
            }
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
            absoluteLayout.Children.Clear();
        }

        void OnTouchEffectTouchAction(object sender, TouchActionEventArgs args)
        {
            AbsoluteLayout absoluteLayout = sender as AbsoluteLayout;
            TouchEffect touchEffect = (TouchEffect)absoluteLayout.Effects.First(e => e is TouchEffect);

            switch (args.Type)
            {
                case TouchActionType.Entered:
                case TouchActionType.Pressed:
                    if (args.IsInContact)
                    {
                        if (!linesInProgress.ContainsKey(args.Id))
                        {
                            FingerPaintInfo info = new FingerPaintInfo
                            {
                                StrokeColor = strokeColor,
                                StrokeThickness = strokeThickness,
                                PreviousPoint = args.Location
                            };
                            linesInProgress.Add(args.Id, info);
                        }
                    }
                    break;

                case TouchActionType.Moved:
                    if (linesInProgress.ContainsKey(args.Id))
                    {
                        FingerPaintInfo info = linesInProgress[args.Id];
                        DrawSimulatedLine(absoluteLayout, info, args.Location);
                        info.PreviousPoint = args.Location;
                    }
                    break;

                case TouchActionType.Released:
                case TouchActionType.Exited:
                case TouchActionType.Cancelled:
                    if (linesInProgress.ContainsKey(args.Id))
                    {
                        FingerPaintInfo info = linesInProgress[args.Id];
                        DrawSimulatedLine(absoluteLayout, info, args.Location);
                        linesInProgress.Remove(args.Id);
                    }
                    break;
            }
        }

        void DrawSimulatedLine(AbsoluteLayout absoluteLayout, FingerPaintInfo info, Point point)
        {
            // Calculate size of BoxView
            double width = Math.Sqrt(Math.Pow(point.X - info.PreviousPoint.X, 2) +
                                     Math.Pow(point.Y - info.PreviousPoint.Y, 2)) +
                           info.StrokeThickness;
            double height = info.StrokeThickness;

            // Find location of BoxView
            Point midPoint = new Point((point.X + info.PreviousPoint.X) / 2,
                                       (point.Y + info.PreviousPoint.Y) / 2);
            Point location = new Point(midPoint.X - width / 2, midPoint.Y - height / 2);

            // Create BoxView and set it in AbsoluteLayout
            BoxView boxView = new BoxView { Color = info.StrokeColor };
            AbsoluteLayout.SetLayoutBounds(boxView, new Rectangle(location.X, location.Y, width, height));
            absoluteLayout.Children.Add(boxView);

            // Rotate it
            double radians = Math.Atan2(point.Y - info.PreviousPoint.Y,
                                        point.X - info.PreviousPoint.X);
            boxView.Rotation = 180 * radians / Math.PI;
        }
    }
}
