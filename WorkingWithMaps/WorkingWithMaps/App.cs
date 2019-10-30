using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WorkingWithMaps
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
