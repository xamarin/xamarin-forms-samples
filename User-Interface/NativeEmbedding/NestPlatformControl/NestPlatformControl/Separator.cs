using Xamarin.Forms;

namespace NestPlatformControl
{
	public sealed class Separator : BoxView
	{
		public Separator ()
		{
			Color = Color.Gray;
			HeightRequest = 2;
			Opacity = 0.5;
			Margin = new Thickness (20, 0, 20, 0);
		}
	}
}

