using System;

namespace TodoCognitive.Models
{
	public class Face
	{
		public Guid FaceId { get; set; }
		public FaceRectangle FaceRectangle { get; set; }
		public FaceLandmarks FaceLandmarks { get; set; }
		public FaceAttributes FaceAttributes { get; set; }
    }
}
