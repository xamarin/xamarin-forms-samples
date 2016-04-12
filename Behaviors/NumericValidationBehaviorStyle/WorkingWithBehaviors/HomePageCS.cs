using Xamarin.Forms;

namespace WorkingWithBehaviors
{
	public class HomePageCS : TabbedPage
	{
		public HomePageCS ()
		{
			Children.Add (new NumericValidationPageCS ());
		}
	}
}


