using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Meetum.Models
{
    public class TestData
    {
        [JsonProperty(PropertyName = "pois")]
        public List<POI> PointsOfInterest { get; set; }
    }
}

