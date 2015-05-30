using System;
using Xamarin.Forms;

namespace BoxViewClock.Views
{
    public static class PageExtensions
    {
        public static Point Center(this Page page) => new Point(page.Width / 2, page.Height / 2);
        public static double Radius(this Page page) => 0.45 * Math.Min(page.Width, page.Height); 
    }
}
