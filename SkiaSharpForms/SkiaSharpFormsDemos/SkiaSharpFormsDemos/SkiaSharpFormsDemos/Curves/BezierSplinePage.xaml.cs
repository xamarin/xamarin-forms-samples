using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;

namespace SkiaSharpFormsDemos.Curves
{
    public partial class BezierSplinePage : ContentPage
    {
        TouchPoint[] touchPoints = new TouchPoint[4];

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

        public BezierSplinePage()
        {
            for (int i = 0; i < 4; i++)
            {
                TouchPoint touchPoint = new TouchPoint
                {
                    Color = new SKColor(0, 0, 0xFF, 0x80),
                    Radius = 100,
                    Center = new SKPoint(200 + 300 * (i % 2),
                                         200 + 300 * i)
                };
                touchPoints[i] = touchPoint;
            }

            InitializeComponent();
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
                path.CubicTo(touchPoints[1].Center, 
                             touchPoints[2].Center, 
                             touchPoints[3].Center);

                canvas.DrawPath(path, strokePaint);
            }

            // Draw tangent lines
            canvas.DrawLine(touchPoints[0].Center.X,
                            touchPoints[0].Center.Y,
                            touchPoints[1].Center.X,
                            touchPoints[1].Center.Y, dottedStrokePaint);

            canvas.DrawLine(touchPoints[2].Center.X,
                            touchPoints[2].Center.Y,
                            touchPoints[3].Center.X,
                            touchPoints[3].Center.Y, dottedStrokePaint);

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
