using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation (XamlCompilationOptions.Compile)]
namespace WorkingWithBehaviors
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new HomePage ();
		}
	}
}
