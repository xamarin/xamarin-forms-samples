using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class RelativeToViewVertical : RelativeToView
	{
		protected override double DetermineExtent( VisualElement view )
		{
			return view.Height;
		}

		protected override double DetermineStart( VisualElement view )
		{
			return view.Y;
		}
	}
}