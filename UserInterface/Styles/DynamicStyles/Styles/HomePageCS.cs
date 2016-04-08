using Xamarin.Forms;

namespace Styles
{
	public class HomePageCS : TabbedPage
	{
		public HomePageCS ()
		{
			Children.Add (new DynamicStylesPageCS ());
			Children.Add (new DynamicStylesInheritancePageCS ());
			Children.Add (new DeviceStylesPageCS ());
		}
	}
}


