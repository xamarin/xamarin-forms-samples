using Xamarin.Forms;

namespace AnimationDemo
{
	public class HomePageCS : TabbedPage
	{
		public HomePageCS ()
		{
			Children.Add (new SimpleAnimationPageCS ());
			Children.Add (new ChildAnimationPageCS ());
			Children.Add (new ColorAnimationPageCS ());
		}
	}
}
