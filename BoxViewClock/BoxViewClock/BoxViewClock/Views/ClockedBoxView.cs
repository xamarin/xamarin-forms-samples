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

        public Point Center => new Point ( Width / 2, Height / 2 );
        public double Radius => Math.Min(Width, Height) * 0.45;
        double Size() => Radius / (Index % 5 == 0 ? 15 : 30);

        public double Radians => Index * 2 * Math.PI / NumberOfSeconds;

        public ClockedBoxView UpdateRotation()
        {
            Rotation = 180 * Radians / Math.PI;
            return this;
        }


        public Rectangle GetRectangle()
        {
            double size = Size();
            double x = Center.X + Radius * Math.Sin(Radians) - size / 2;
            double y = Center.Y - Radius * Math.Cos(Radians) - size / 2;
            return new Rectangle(x, y, size, size);
        }

    }
}
