using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TodoCognitive.Models
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum NoiseLevel
	{
		Low,
        Medium,
        High
	}

    public class Noise
    {
		public NoiseLevel NoiseLevel { get; set; }
		public double Value { get; set; }
    }
}
