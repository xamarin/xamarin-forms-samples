using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;

namespace SkiaSharpFormsDemos.Curves
{
    public partial class ConicSplinePage : ContentPage
    {
        TouchPoint[] touchPoints = new TouchPoint[3];

        SKPaint strokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 3
        };

        SKPaint dottedStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 3,
            PathEffect = SKPathEffect.CreateDash(new float[] { 7, 7 }, 0)
        };

        public ConicSplinePage()
        {
            for (int i = 0; i < 3; i++)
            {
                TouchPoint touchPoint = new TouchPoint
                {
                    Center = new SKPoint(100 + 200 * i,
                                         100 + (i == 1 ? 300 : 0))
                };
                touchPoints[i] = touchPoint;
            }

            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPath path = new SKPath())
            {
                path.MoveTo(touchPoints[0].Center);
                path.ConicTo(touchPoints[1].Center,
                             touchPoints[2].Center,
                             (float)weightSlider.Value);

                canvas.DrawPath(path, strokePaint);
            }

            // Draw tangent lines
            canvas.DrawLine(touchPoints[0].Center.X,
                            touchPoints[0].Center.Y,
                            touchPoints[1].Center.X,
                            touchPoints[1].Center.Y, dottedStrokePaint);

            canvas.DrawLine(touchPoints[1].Center.X,
                            touchPoints[1].Center.Y,
                            touchPoints[2].Center.X,
                            touchPoints[2].Center.Y, dottedStrokePaint);

            foreach (TouchPoint touchPoint in touchPoints)
            {
                touchPoint.Paint(canvas);
            }
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            bool touchPointMoved = false;

            foreach (TouchPoint touchPoint in touchPoints)
            {
                float scale = canvasView.CanvasSize.Width / (float)canvasView.Width;
                SKPoint point = new SKPoint(scale * (float)args.Location.X,
                                            scale * (float)args.Location.Y);
                touchPointMoved |= touchPoint.ProcessTouchEvent(args.Id, args.Type, point);
            }

            if (touchPointMoved)
            {
                canvasView.InvalidateSurface();
            }
        }
    }
}
