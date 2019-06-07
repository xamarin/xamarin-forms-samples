using Xamarin.Forms;

namespace NotificationHubSample
{
    public partial class App : Application
    {
        public const string NotificationReceivedKey = "NotificationReceived";

        public App()
        {
            InitializeComponent();

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
