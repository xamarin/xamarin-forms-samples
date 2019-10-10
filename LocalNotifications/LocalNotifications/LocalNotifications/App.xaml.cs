using Xamarin.Forms;

namespace LocalNotifications
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // use the dependency service to get a platform-specific implementation and initialize it
            DependencyService.Get<INotificationManager>().Initialize();

            MainPage = new MainPage();
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
