using System;
using Xamarin.Forms;

namespace LocalNotifications
{
    public partial class MainPage : ContentPage
    {
        INotificationManager notificationManager;
        int notificationNumber = 0;
        public MainPage()
        {
            InitializeComponent();

            notificationManager = ((App)App.Current).NotificationManager;
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        private void OnScheduleClick(object sender, EventArgs e)
        {
            notificationNumber++;
            string title = $"Local Notification #{notificationNumber}";
            string message = $"You have now received {notificationNumber} notifications!";
            notificationManager.ScheduleNotification(title, message);
        }

        private void ShowNotification(string title, string message)
        {
            // this could be dispatched from other threads, since UI is affected we
            // must make sure we're on the UI thread
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                stackLayout.Children.Add(msg);
            });
        }
    }
}
