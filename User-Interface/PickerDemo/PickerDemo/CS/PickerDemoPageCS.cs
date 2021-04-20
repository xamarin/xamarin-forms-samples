using Xamarin.Forms;

namespace PickerDemo
{
	public class PickerDemoPageCS : TabbedPage
	{
		public PickerDemoPageCS()
		{
			Children.Add(new PickerItemsSourcePageCS());
			Children.Add(new PickerItemsPageCS());
		}
	}
}
