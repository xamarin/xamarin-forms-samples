using Xamarin.Forms;

namespace AttachedNumericValidationBehavior
{
	public class HomePageCS : TabbedPage
	{
		public HomePageCS ()
		{
			Children.Add (new NumericValidationPageCS ());
		}
	}
}
