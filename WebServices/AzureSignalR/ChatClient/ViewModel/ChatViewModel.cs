using ChatClient.Model;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatClient.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private HubConnection _connection;
        private Command _sendMessageCommand;
        private Command _connectCommand;
        private bool _isBusy;
        private bool _isConnected;
        private string _messageText = "Nothing yet";

        public ObservableCollection<Message> Messages
        {
            get;
            private set;
        }

        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                if (_isConnected == value)
                {
                    return;
                }

                _isConnected = value;
                RaisePropertyChanged();
                ConnectCommand.ChangeCanExecute();
                SendMessageCommand.ChangeCanExecute();
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy == value)
                {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged();
                SendMessageCommand.ChangeCanExecute();
            }
        }

        public string MessageText
        {
            get
            {
                return _messageText;
            }
            set
            {
                if (_messageText == value)
                {
                    return;
                }

                _messageText = value;
                RaisePropertyChanged();
                SendMessageCommand.ChangeCanExecute();
            }
        }

        public Command SendMessageCommand => _sendMessageCommand ??
            (_sendMessageCommand = new Command<string>(
                async obj => await SendMessageAsync(),
                obj => IsConnected
                    && !IsBusy
                    && !string.IsNullOrEmpty(MessageText)));

        public Command ConnectCommand => _connectCommand ??
            (_connectCommand = new Command<string>(
                async obj => await ConnectToServerAsync(),
                obj => !IsConnected && !IsBusy));

        public ChatViewModel()
        {
            Messages = new ObservableCollection<Message>();
        }

        private async Task SendMessageAsync()
        {
            IsBusy = true;
            var user = Constants.Username;
            var newMessage = new Message
            {
                Name = user,
                Text = MessageText
            };

            var json = JsonConvert.SerializeObject(newMessage);

            var client = new HttpClient();

            var content = new StringContent(
                json, 
                Encoding.UTF8, 
                "application/json");

            var result = await client.PostAsync(
                $"{Constants.HostName}/api/talk", 
                content);

            IsBusy = false;
        }

        public async Task ConnectToServerAsync()
        {
            try
            {
                IsBusy = true;

                var client = new HttpClient();
                var negotiateJson = await client.GetStringAsync($"{Constants.HostName}/api/negotiate");

                var negotiateInfo = JsonConvert.DeserializeObject<NegotiateInfo>(negotiateJson);

                _connection = new HubConnectionBuilder()
                    .WithUrl(negotiateInfo.Url, options =>
                    {
                        options.AccessTokenProvider = async () => negotiateInfo.AccessToken;
                    })
                    .Build();

                _connection.On<JObject>("newMessage", AddNewMessage);

                await _connection.StartAsync();

                IsConnected = true;
                IsBusy = false;
            }
            catch (Exception)
            {
                Debugger.Break();
            }
        }

        private void AddNewMessage(JObject message)
        {
            var name = message.GetValue("name").ToString();
            var text = message.GetValue("text").ToString();

            var newMessage = new Message
            {
                Name = name,
                Text = text,
                TimeReceived = DateTime.Now
            };

            Device.BeginInvokeOnMainThread(() =>
            {
                Messages.Insert(0, newMessage);
            });
        }

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
