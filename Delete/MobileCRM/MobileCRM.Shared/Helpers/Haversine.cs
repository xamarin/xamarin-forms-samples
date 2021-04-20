using System;

namespace MobileCRM.Shared.Helpers
{
    public static class Haversine
    {
        /// <summary>
        /// Radius of the Earth in Kilometers.
        /// </summary>
        private const double EARTH_RADIUS_KM = 6371;

        /// <summary>
        /// Converts an angle to a radian.
        /// </summary>
        /// <param name="input">The angle that is to be converted.</param>
        /// <returns>The angle in radians.</returns>
        private static double ToRad(double input)
        {
            return input * (Math.PI / 180);
        }

        /// <summary>
        /// Calculates the distance between two geo-points in kilometers using the Haversine algorithm.
        /// </summary>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <returns>A double indicating the distance between the points in KM.</returns>
        public static double GetDistanceKM(LatLon point1, LatLon point2)
        {
            double dLat = ToRad(point2.Latitude - point1.Latitude);
            double dLon = ToRad(point2.Longtitude - point1.Longtitude);

            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                Math.Cos(ToRad(point1.Latitude)) * Math.Cos(ToRad(point2.Latitude)) *
                Math.Pow(Math.Sin(dLon / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EARTH_RADIUS_KM * c;
            return distance;
        }
    }

    public struct LatLon
    {
        public double Latitude;
        public double Longtitude;

        public LatLon(double latitude, double longtitude)
        {
            Latitude = latitude;
            Longtitude = longtitude;
        }
    }
}

