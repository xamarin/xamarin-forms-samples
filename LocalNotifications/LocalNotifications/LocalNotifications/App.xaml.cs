using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalNotifications
{
    public partial class App : Application
    {
        // interface instance can be implemented natively on each platform
        public INotificationManager NotificationManager { get; private set; }

        public App()
        {
            InitializeComponent();

            // use the dependency service to get a platform-specific implementation and initialize it
            NotificationManager = DependencyService.Get<INotificationManager>();
            NotificationManager.Initialize();

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
