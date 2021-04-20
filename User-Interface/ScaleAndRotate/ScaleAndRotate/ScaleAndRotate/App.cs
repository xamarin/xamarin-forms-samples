using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace ScaleAndRotate
{
	public class App : Application
    {
		public App ()
        {
            MainPage = new NavigationPage(new HomePage());
        }
    }
}
