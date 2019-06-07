using ChatClient.ViewModel;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
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

        private void AddMessage(string message)
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

        private void SignalR_NewMessageReceived(object sender, Model.Message message)
        {
            string msg = $"{message.Name} ({message.TimeReceived}) - {message.Text}";
            AddMessage(msg);
        }

        private void SignalR_ConnectionChanged(object sender, bool success, string message)
        {
            connectButton.Text = "Connect";
            connectButton.IsEnabled = !success;
            sendButton.IsEnabled = success;

            AddMessage($"Server connection changed: {message}");
        }

        private async void ConnectButton_ClickedAsync(object sender, EventArgs e)
        {
            connectButton.Text = "Connecting...";
            connectButton.IsEnabled = false;
            await signalR.ConnectAsync();
        }

        private async void SendButton_ClickedAsync(object sender, EventArgs e)
        {
            await signalR.SendMessageAsync(Constants.Username, messageEntry.Text);
            messageEntry.Text = "";
        }
    }
}
