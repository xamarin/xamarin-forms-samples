using System;
using Xamarin.Forms;

namespace BoxViewClock.Views
{
    public class HandedBoxView : BoxView
    {
        private struct HandParams
        {
            public HandParams(double width, double height, double offset) : this()
            {
                Width = width;
                Height = height;
                Offset = offset;
            }

            public double Width { get; }   // fraction of radius
            public double Height { get; }  // ditto
            public double Offset { get; }  // relative to center pivot
        }

        private HandParams Params { get; }

        public HandedBoxView(double width, double height, double offset):base()
        {
            Params = new HandParams(width, height, offset);
        }

        public Rectangle GetRectangle (Page page)
        {
            Point center = page.Center();
            double radius = page.Radius();
            double width = Params.Width * radius;
            double height = Params.Height * radius;
            double offset = Params.Offset;
            return new Rectangle(
                center.X - 0.5 * width,
                center.Y - offset * height,
                width,
                height
            );
        }

        public void UpdateLayout(Page page)
        {
            AbsoluteLayout.SetLayoutBounds(this, GetRectangle(page));
            AnchorX = 0.51;
            AnchorY = Params.Offset;
        }
    }

}
