using System;
using System.Collections.Generic;
using MapOverlay;
using MapOverlay.Tizen;
using Tizen.Maps;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Tizen;
using Xamarin.Forms.Platform.Tizen;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.Tizen
{
    public static class GeocoordinateExtension
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        static public double ToDegrees(this double radians)
        {
            return radians * (180 / Math.PI);
        }
    };

    public class CustomMapRenderer : MapRenderer
    {
        const int EarthRadiusInMeteres = 6371000;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }
            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MapView;
                var circle = formsMap.Circle;

                var coordinates = new List<Geocoordinates>();
                var positions = GenerateCircleCoordinates(circle.Position, circle.Radius);
                foreach (var position in positions)
                {
                    coordinates.Add(new Geocoordinates(position.Latitude, position.Longitude));
                }

                var polygon = new Polygon(coordinates, ElmSharp.Color.FromRgba(255, 0, 0, 128));
                polygon.FillColor = ElmSharp.Color.FromRgba(255, 0, 0, 128);
                nativeMap.Add(polygon);
            }
        }

        List<Position> GenerateCircleCoordinates(Position position, double radius)
        {
            double latitude = position.Latitude.ToRadians();
            double longitude = position.Longitude.ToRadians();
            double distance = radius / EarthRadiusInMeteres;
            var positions = new List<Position>();

            for (int angle = 0; angle <=360; angle++)
            {
                double angleInRadians = ((double)angle).ToRadians();
                double latitudeInRadians = Math.Asin(Math.Sin(latitude) * Math.Cos(distance) + Math.Cos(latitude) * Math.Sin(distance) * Math.Cos(angleInRadians));
                double longitudeInRadians = longitude + Math.Atan2(Math.Sin(angleInRadians) * Math.Sin(distance) * Math.Cos(latitude), Math.Cos(distance) - Math.Sin(latitude) * Math.Sin(latitudeInRadians));

                var pos = new Position(latitudeInRadians.ToDegrees(), longitudeInRadians.ToDegrees());
                positions.Add(pos);
            }

            return positions;
        }
    }
}
