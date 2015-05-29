using System;
using Xamarin.Forms;

namespace BoxViewClock.Views
{
    public class ClockedBoxView : BoxView
    {
        private const int NumberOfSeconds = 60;
        public int Index{ get;}

        public ClockedBoxView(int index):base()
        {
            Index = index;
        }
        public double Radians => Index * 2 * Math.PI / NumberOfSeconds;

        Point Center(Page page) => new Point (page.Width / 2, page.Height / 2 );
        double Radius(Page page) => Math.Min(page.Width, page.Height) * 0.45;
        double Size(Page page) => Radius(page) / (Index % 5 == 0 ? 15 : 30);

        public ClockedBoxView UpdateRotation()
        {
            Rotation = 180 * Radians / Math.PI;
            return this;
        }

        public Rectangle GetRectangle(Page page)
        {
            Point center = Center(page);
            double size = Size(page);
            double radius = Radius(page);
            double x = center.X + radius * Math.Sin(Radians) - size / 2;
            double y = center.Y - radius * Math.Cos(Radians) - size / 2;
            return new Rectangle(x, y, size, size);
        }

    }
}
