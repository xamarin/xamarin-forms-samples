using System;

namespace MapOverlay.UWP
{
    public static class DoubleExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        static public double ToDegrees(this double radians)
        {
            return radians * (180 / Math.PI);
        }
    }
}
