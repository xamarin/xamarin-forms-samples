using Xamarin.Forms;

namespace TabbedPageWithNavigationPage
{
	public class MainPageCS : TabbedPage
	{
		public MainPageCS ()
		{
			var navigationPage = new NavigationPage (new SchedulePageCS ());
			navigationPage.Icon = "schedule.png";
			navigationPage.Title = "Schedule";

			Children.Add (new TodayPageCS ());
			Children.Add (navigationPage);
			Children.Add (new SettingsPage ());
		}
	}
}
