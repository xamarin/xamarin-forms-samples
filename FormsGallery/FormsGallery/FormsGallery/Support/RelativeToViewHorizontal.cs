using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class RelativeToViewHorizontal : RelativeToView
	{
		protected override double DetermineExtent( VisualElement view )
		{
			return view.Width;
		}

		protected override double DetermineStart( VisualElement view )
		{
			return view.X;
		}
	}
}