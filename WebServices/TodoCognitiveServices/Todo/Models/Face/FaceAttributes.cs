using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Todo.Models
{
	public class FaceAttributes
	{
		public double Age { get; set; }
		public string Gender { get; set; }
		public HeadPose HeadPose { get; set; }
		public double Smile { get; set; }
		public FacialHair FacialHair { get; set; }
		public EmotionScores Emotion { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public Glasses Glasses { get; set; }
		public Blur Blur { get; set; }
		public Exposure Exposire { get; set; }
		public Noise Noise { get; set; }
		public Makeup Makeup { get; set; }
		public Accessory[] Accessories { get; set; }
		public Occlusion Occlusion { get; set; }
		public FacialHair Hair { get; set; }
	}

    public class HeadPose
	{
		public double Roll { get; set; }
		public double Yaw { get; set; }
		public double Pitch { get; set; }
	}

    public class FacialHair
	{
		public double Moustache { get; set; }
		public double Beard { get; set; }
		public double Sideburns { get; set; }
	}
}
