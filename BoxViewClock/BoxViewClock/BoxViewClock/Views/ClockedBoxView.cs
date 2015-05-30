using System;
using Xamarin.Forms;

namespace BoxViewClock.Views
{
    public class ClockedBoxView : BoxView, IUpdateLayoutable
    {
        private const int NumberOfSeconds = 60;
        public int Index{ get;}

        public ClockedBoxView(int index):base()
        {
            Index = index;
        }
        public double Radians => Index * 2 * Math.PI / NumberOfSeconds;
        double Size(Page page) => page.Radius() / (Index % 5 == 0 ? 15 : 30);

        private ClockedBoxView UpdateRotation()
        {
            Rotation = 180 * Radians / Math.PI;
            return this;
        }

        public Rectangle GetRectangle(Page page)
        {
            Point center = page.Center();
            double size = Size(page);
            double radius = page.Radius();
            double x = center.X + radius * Math.Sin(Radians) - size / 2;
            double y = center.Y - radius * Math.Cos(Radians) - size / 2;
            return new Rectangle(x, y, size, size);
        }

        public void UpdateLayout(Page page)
        {
            AbsoluteLayout.SetLayoutBounds(this, GetRectangle(page));
            AnchorX = 0.51;        // Anchor settings necessary for Android
            AnchorY = 0.51;
            UpdateRotation();
        }

    }
}
