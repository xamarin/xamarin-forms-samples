using System;
using Xamarin.Forms;

namespace ChatClient
{
    public partial class MainPage : ContentPage
    {
        SignalRService signalR;

        public MainPage()
        {
            InitializeComponent();

            signalR = new SignalRService();
            signalR.Connected += SignalR_ConnectionChanged;
            signalR.ConnectionFailed += SignalR_ConnectionChanged;
            signalR.NewMessageReceived += SignalR_NewMessageReceived;
        }

        void AddMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Label label = new Label
                {
                    Text = message,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start
                };

                messageList.Children.Add(label);
            });
        }

        void SignalR_NewMessageReceived(object sender, Model.Message message)
        {
            string msg = $"{message.Name} ({message.TimeReceived}) - {message.Text}";
            AddMessage(msg);
        }

        void SignalR_ConnectionChanged(object sender, bool success, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                connectButton.Text = "Connect";
                connectButton.IsEnabled = !success;
                sendButton.IsEnabled = success;
                AddMessage($"Server connection changed: {message}");
            });
        }

        async void ConnectButton_ClickedAsync(object sender, EventArgs e)
        {
            connectButton.Text = "Connecting...";
            connectButton.IsEnabled = false;
            await signalR.ConnectAsync();
        }

        async void SendButton_ClickedAsync(object sender, EventArgs e)
        {
            await signalR.SendMessageAsync(Constants.Username, messageEntry.Text);
            messageEntry.Text = "";
        }
    }
}
