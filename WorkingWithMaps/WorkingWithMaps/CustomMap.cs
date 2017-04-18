using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MarineOps.Common.CustomRenderers
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }

    }
}
