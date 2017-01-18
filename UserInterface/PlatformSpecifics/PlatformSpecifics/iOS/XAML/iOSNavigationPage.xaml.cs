using Xamarin.Forms;

namespace PlatformSpecifics
{
	public partial class iOSNavigationPage : NavigationPage
	{
		public iOSNavigationPage()
		{
			InitializeComponent();
			PushAsync(new iOSTranslucentNavigationBarPage());
		}
	}
}
