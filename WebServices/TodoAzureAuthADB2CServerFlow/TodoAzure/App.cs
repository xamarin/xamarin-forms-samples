using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoAzure
{
    public class App : Application
    {
        public static IAuthenticate Authenticator { get; private set; }

        public App()
        {
            Authenticator = DependencyService.Get<IAuthenticate>();
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

