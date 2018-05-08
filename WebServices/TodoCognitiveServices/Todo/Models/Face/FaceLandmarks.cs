namespace Todo.Models
{
	public class FeatureCoordinate
	{
		public double X { get; set; }
		public double Y { get; set; }
	}

    public class FaceLandmarks
    {
        public FeatureCoordinate PupilLeft { get; set; }
		public FeatureCoordinate PupilRight { get; set; }
		public FeatureCoordinate NoseTip { get; set; }      
		public FeatureCoordinate MouthLeft { get; set; }      
		public FeatureCoordinate MouthRight { get; set; }      
		public FeatureCoordinate EyebrowLeftOuter { get; set; }
		public FeatureCoordinate EyebrowLeftInner { get; set; }
		public FeatureCoordinate EyeLeftOuter { get; set; }
		public FeatureCoordinate EyeLeftTop { get; set; }      
		public FeatureCoordinate EyeLeftBottom { get; set; }
		public FeatureCoordinate EyeLeftInner { get; set; }      
		public FeatureCoordinate EyebrowRightInner { get; set; }
		public FeatureCoordinate EyebrowRightOuter { get; set; }
		public FeatureCoordinate EyeRightInner { get; set; }
        public FeatureCoordinate EyeRightTop { get; set; }
		public FeatureCoordinate EyeRightBottom { get; set; }    
		public FeatureCoordinate EyeRightOuter { get; set; }      
		public FeatureCoordinate NoseRootLeft { get; set; }   
		public FeatureCoordinate NoseRootRight { get; set; }      
		public FeatureCoordinate NoseLeftAlarTop { get; set; }
		public FeatureCoordinate NoseRightAlarTop { get; set; }
		public FeatureCoordinate NoseLeftAlarOutTip { get; set; }       
		public FeatureCoordinate NoseRightAlarOutTip { get; set; }
		public FeatureCoordinate UpperLipTop { get; set; }      
		public FeatureCoordinate UpperLipBottom { get; set; }
        public FeatureCoordinate UnderLipTop { get; set; }      
		public FeatureCoordinate UnderLipBottom { get; set; }
    }
}
