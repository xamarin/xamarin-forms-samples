using Xamarin.UITest;

namespace TodoPCLTests
{
	public abstract class BasePage
	{
		protected readonly IApp app;
		protected readonly bool OnAndroid, OniOS;

		protected BasePage(IApp app, Platform platform)
		{
			this.app = app;

			OnAndroid = platform == Platform.Android;
			OniOS = platform == Platform.iOS;
		}
	}
}
