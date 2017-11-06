using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Identity.Client;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoAzure
{
    public class App : Application
    {
        public static IAuthenticate AuthenticationProvider { get; private set; }

        public static UIParent UiParent = null;

        public App()
        {
            AuthenticationProvider = new AuthenticationProvider();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

