using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace Forms2Native
{
	public class App : Application
	{
		public const string NativeNavigationMessage = "Forms2Native.NativeNavigationMessage";

		public App ()
		{
			var mainNav = new NavigationPage (new MyFirstPage ()); 

			MainPage = mainNav;
		}
	}
}