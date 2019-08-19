using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation (XamlCompilationOptions.Compile)]
namespace AttachedNumericValidationBehavior
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new HomePage ();
		}
	}
}
