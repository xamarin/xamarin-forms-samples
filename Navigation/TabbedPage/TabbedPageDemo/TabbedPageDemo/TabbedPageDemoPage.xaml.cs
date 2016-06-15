using Xamarin.Forms;

namespace TabbedPageDemo
{
	public partial class TabbedPageDemoPage : TabbedPage
	{
		public TabbedPageDemoPage ()
		{
			InitializeComponent ();
			ItemsSource = MonkeyDataModel.All;
		}
	}
}
