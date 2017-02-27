using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;

namespace SkiaSharpFormsDemos.Curves
{
    public class InteractivePage : ContentPage
    {
        protected SKCanvasView baseCanvasView;

   //     TouchEffect touchEffect;

        protected TouchPoint[] touchPoints;



        protected SKPaint strokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 3
        };

        protected SKPaint redStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Red,
            StrokeWidth = 3
        };

        protected SKPaint dottedStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 3,
            PathEffect = SKPathEffect.CreateDash(new float[] { 7, 7 }, 0)
        };






        public InteractivePage()
        {
        }




        protected void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            bool touchPointMoved = false;

            foreach (TouchPoint touchPoint in touchPoints)
            {
                float scale = baseCanvasView.CanvasSize.Width / (float)baseCanvasView.Width;
                SKPoint point = new SKPoint(scale * (float)args.Location.X,
                                            scale * (float)args.Location.Y);
                touchPointMoved |= touchPoint.ProcessTouchEvent(args.Id, args.Type, point);
            }

            if (touchPointMoved)
            {
                baseCanvasView.InvalidateSurface();
            }
        }

    }
}
