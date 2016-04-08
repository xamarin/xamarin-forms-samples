using Xamarin.Forms;

namespace Styles
{
	public class HomePageCS : TabbedPage
	{
		public HomePageCS ()
		{
			Children.Add (new NoStylesPageCS ());
			Children.Add (new ExplicitStylesPageCS ());
			Children.Add (new ImplicitStylesPageCS ());
			Children.Add (new ApplicationStylesPageCS ());
			Children.Add (new StyleInheritancePageCS ());
		}
	}
}
