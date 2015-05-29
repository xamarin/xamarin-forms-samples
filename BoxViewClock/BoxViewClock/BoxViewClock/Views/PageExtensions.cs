using System;
using Xamarin.Forms;

namespace BoxViewClock.Views
{
    public static class PageExtensions
    {
        public static Point Center(this Page page)
        {
            return new Point(page.Width / 2, page.Height / 2);
        }

        public static double Radius(this Page page)
        {
            return Math.Min(page.Width, page.Height);
        }
    }
}
