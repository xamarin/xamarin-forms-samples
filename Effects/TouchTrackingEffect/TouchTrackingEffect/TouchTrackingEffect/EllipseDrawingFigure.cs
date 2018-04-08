using System;
using Xamarin.Forms;
using SkiaSharp;

namespace TouchTrackingEffectDemos
{
    class EllipseDrawingFigure
    {
        SKPoint pt1, pt2;

        public EllipseDrawingFigure()
        {
        }

        public SKColor Color { set; get; }

        public SKPoint StartPoint
        {
            set
            {
                pt1 = value;
                MakeRectangle();
            } 
        }

        public SKPoint EndPoint
        {
            set
            {
                pt2 = value;
                MakeRectangle();
            }
        }

        void MakeRectangle()
        {
            Rectangle = new SKRect(pt1.X, pt1.Y, pt2.X, pt2.Y).Standardized;
        }

        public SKRect Rectangle { set; get; }

        // For dragging operations
        public Point LastFingerLocation { set; get; }

        // For the dragging hit-test
        public bool IsInEllipse(SKPoint pt)
        {
            SKRect rect = Rectangle;

            return (Math.Pow(pt.X - rect.MidX, 2) / Math.Pow(rect.Width / 2, 2) +
                    Math.Pow(pt.Y - rect.MidY, 2) / Math.Pow(rect.Height / 2, 2)) < 1;
        }
    }
}
