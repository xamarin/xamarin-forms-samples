using System;
using Xamarin.Forms;

namespace WorkingWithTriggers
{
	public class VisualElementPopTriggerAction : TriggerAction<VisualElement>
	{
		public VisualElementPopTriggerAction()
		{
			Anchor = new Point(0.5, 0.5);
			Scale = 2;
			Length = 500;
		}

		public Point Anchor { set; get; }

		public double Scale { set; get; }

		public uint Length { set; get; }

		protected override async void Invoke(VisualElement visual)
		{
			visual.AnchorX = Anchor.X;
			visual.AnchorY = Anchor.Y;
			await visual.ScaleTo(Scale, Length / 2, Easing.SinOut);
			await visual.ScaleTo(1, Length / 2, Easing.SinIn);
		}
	}
}