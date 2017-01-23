using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using TouchTracking;


namespace TouchTrackingEffectDemos
{
    class FingerPaintInfo
    {
        public FingerPaintInfo()
        {
   //         Points = new List<Point>();
        }

   //     public List<Point> Points { private set; get; }

        public Point PreviousPoint { set; get; }

        public Color StrokeColor { set; get; }

        public double StrokeWidth { set; get; }
    }


    public partial class FingerPaintPage : ContentPage
    {
        Dictionary<long, FingerPaintInfo> linesInProgress = new Dictionary<long, FingerPaintInfo>();

        public FingerPaintPage()
        {
            InitializeComponent();

      //      TouchEffect touchEffect = new TouchEffect();
        //    touchEffect.TouchAction += OnTouchEffectTouchAction;
        }

        void OnTouchEffectTouchAction(object sender, TouchActionEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine(args.Type);

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
                                StrokeColor = Color.Blue,
                                StrokeWidth = 5,
                                PreviousPoint = args.Location
                            };
                        }
                    }
                    break;

                case TouchActionType.Moved:
                    if (linesInProgress.ContainsKey(args.Id))
                    {
                        FingerPaintInfo info = linesInProgress[args.Id];
                        DrawSimulatedLine(info, args.Location);
                        info.PreviousPoint = args.Location;
                    }
                    break;

                case TouchActionType.Released:
                case TouchActionType.Exited:
                case TouchActionType.Cancelled:
                    if (linesInProgress.ContainsKey(args.Id))
                    {
                        FingerPaintInfo info = linesInProgress[args.Id];
                        DrawSimulatedLine(info, args.Location);
                        linesInProgress.Remove(args.Id);
                    }
                    break;
            }
        }

        void DrawSimulatedLine(FingerPaintInfo info, Point point)
        {




        }
    }
}
