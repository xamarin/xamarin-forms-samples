using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MarineOps.Common.CustomRenderers
{
    public class CustomPin
    {
        public Pin Pin { get; set; }

        public string Id { get; set; }

        public double Angle { get; set; }

        public string Url { get; set; }

        public bool ShowCallout { get; set; }

        public string Filename { get; set; }

        public List<Position> RouteCoordinates { get; set; }

        public static explicit operator CustomPin(Pin v)
        {
            throw new NotImplementedException();
        }

        public CustomPin()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}

