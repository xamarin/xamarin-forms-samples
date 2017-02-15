using System;
using Xamarin.Forms;
using SkiaSharp;

namespace TouchTrackingEffectDemos
{
    class EllipseDrawingFigure
    {
        public EllipseDrawingFigure()
        {
        }

        public SKColor Color { set; get; }

        public SKPoint StartPoint { set; get; }

        public SKPoint EndPoint { set; get; }

        public SKRect InterimRectangle
        {
            get
            {
                return new SKRect(StartPoint.X, StartPoint.Y, 
                                  EndPoint.X, EndPoint.Y).Standardized;
            }
        }

        // Only valid after the ellipse has been completed
        public SKRect Rectangle { set; get; }

        // For dragging operations
        public Point LastFingerLocation { set; get; }

        // For the dragging hit-test
        public bool IsInEllipse(SKPoint pt)
        {
            SKRect rect = Rectangle;

            // Eliminate the obvious
            if (!rect.Contains(pt))
                return false;

            // Unlikely but the tests must be done
            if (pt.X == rect.MidX || pt.Y == rect.MidY)
                return true;

            // Determine the angle from the center
            double angle = Math.Atan2(pt.Y - rect.MidY, pt.X - rect.MidX);

            // The basic test
            return (Math.Abs(pt.X - rect.MidX) < Math.Abs(rect.Width / 2 * Math.Cos(angle)) &&
                    Math.Abs(pt.Y - rect.MidY) < Math.Abs(rect.Height / 2 * Math.Sin(angle)));
        }
    }
}
