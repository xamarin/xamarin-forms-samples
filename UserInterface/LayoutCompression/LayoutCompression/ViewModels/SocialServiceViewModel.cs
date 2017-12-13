using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LayoutCompression
{
    public class SocialServiceViewModel : INotifyPropertyChanged
    {
        public ICommand ConnectCommand { get; private set; }

        public SocialServiceViewModel()
        {

            ConnectCommand = new Command(async _ => await OnConnect());
        }

        public async Task OnConnect()
        {

            if (IsConnectingOrConnected)
            {
                // cancel or disconnect
                //SocialSvc.Disconnect(_network);
                //RaiseAllPropertiesChanged();
            }
            else
            {
                IsConnecting = !IsConnecting;
                //SocialSvc.Connect(_network, (isConnected) =>
                //{
                //  IsConnecting = false;
                //});
            }
        }

        private string _network;
        public string Network
        {
            get
            {
                return _network;
            }
            set
            {
                _network = value;
                RaisePropertyChanged(nameof(Network));
            }
        }

        private bool _isConnecting = false;
        public bool IsConnecting
        {
            get
            {
                return _isConnecting;
            }
            set
            {
                _isConnecting = value;
                RaisePropertyChanged(nameof(IsConnecting));
                RaisePropertyChanged(nameof(BgColor));
                RaisePropertyChanged(nameof(LabelColor));
                RaisePropertyChanged(nameof(IsDisconnected));
                RaisePropertyChanged(nameof(IsConnectingOrConnected));
            }
        }

        public bool IsConnectingOrConnected
        {
            get
            {
                return _isConnecting || !IsDisconnected;
            }
        }

        public bool IsDisconnected
        {
            get
            {
                //var account = SocialSvc.GetAccount(_network);
                //return account == null;
                return true;
            }
        }

        private string _disconnectedImageUrl;
        public string DisconnectedImageUrl
        {
            get
            {
                return _disconnectedImageUrl;
            }
            set
            {
                _disconnectedImageUrl = value;
                RaisePropertyChanged(nameof(DisconnectedImageUrl));
            }
        }

        private string _connectedImageUrl;
        public string ConnectedImageUrl
        {
            get
            {
                return _connectedImageUrl;
            }
            set
            {
                _connectedImageUrl = value;
                RaisePropertyChanged(nameof(ConnectedImageUrl));
            }
        }

        public string BgColor
        {
            get
            {
                if (_isConnecting || !IsDisconnected)
                {
                    return "#FF3F56";
                }
                else
                {
                    return "#ffffff";
                }

            }
            set
            {
                RaisePropertyChanged(nameof(BgColor));
            }
        }

        public string LabelColor
        {
            get
            {
                if (_isConnecting || !IsDisconnected)
                {
                    return "#ffffff";
                }
                else
                {
                    return "#D5D5D5";
                }

            }
            set
            {
                RaisePropertyChanged(nameof(LabelColor));
            }
        }

        public bool CanConnect
        {
            get
            {
                return _canConnect;
            }

            set
            {
                _canConnect = value;
                RaisePropertyChanged(nameof(CanConnect));
            }
        }

        private bool _canConnect = true;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
