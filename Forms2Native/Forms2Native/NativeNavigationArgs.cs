using Xamarin.Forms;

namespace Forms2Native
{
	public class NativeNavigationArgs
	{
		public Page Page { get; private set; }

		public NativeNavigationArgs(Page page)
		{
			Page = page;
		}
	}
}

