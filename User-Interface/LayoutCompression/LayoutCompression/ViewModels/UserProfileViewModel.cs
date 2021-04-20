using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LayoutCompression
{
    public class UserProfileViewModel : INotifyPropertyChanged
    {
        User _user;
        protected User Model
        {
            get
            {
                return _user;
            }
        }

        public string Title
        {
            get
            {
                if (Model != null && Model.ID > 0)
                {
                    return "EDIT PROFILE";
                }
                else
                {
                    return "CREATE A PROFILE";
                }
            }
        }

        bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }
            set
            {
                _isLoggedIn = value;
                RaisePropertyChanged(nameof(IsLoggedIn));
                RaisePropertyChanged(nameof(CanEdit));
                RaisePropertyChanged(nameof(CanSave));
            }
        }

        #region UserEmail

        public string _username;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;

                RaisePropertyChanged(nameof(Username));
            }
        }

        private string _userEmail;
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                RaisePropertyChanged(nameof(UserEmail));
            }
        }

        #endregion

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        #region UserPassword

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                PasswordStrength = JudgePasswordStrength(_userPassword);
                RaisePropertyChanged(nameof(UserPassword));
            }
        }

        private string _confirmUserPassword;
        public string ConfirmUserPassword
        {
            get { return _confirmUserPassword; }
            set
            {
                _confirmUserPassword = value;
                RaisePropertyChanged(nameof(ConfirmUserPassword));
            }
        }

        #endregion

        private int _passwordStrength = 1;
        public int PasswordStrength
        {
            get { return _passwordStrength; }
            set
            {
                _passwordStrength = value;
                RaisePropertyChanged(nameof(PasswordStrength));
            }
        }

        int JudgePasswordStrength(string _userPassword)
        {
            var result = PasswordAdvisor.CheckStrength(_userPassword);
            return (int)result + 1; // 1-6
        }

        public Action<string, string> DisplayPrompt = delegate
        {
        };

        public ICommand SaveCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public ICommand SelectPhotoCommand { get; private set; }

        public ICommand SkipCommand { get; private set; }

        public ICommand LogoutCommand { get; private set; }

        public ICommand ToggleEditModeCommand { get; private set; }

        public UserProfileViewModel()
        {
            InitMockData();

            SaveCommand = new Command(async _ => await OnSave());
            //SkipCommand = new Command(async _ => await OnSkip());
            //CancelCommand = new Command(async _ => await OnCancel());
            //SelectPhotoCommand = new Command(async _ => await OnSelectPhoto());
            LogoutCommand = new Command(async _ => await OnLogout());
            ToggleEditModeCommand = new Command(async _ => await OnToggleEditMode());

            FacebookVM = new SocialServiceViewModel()
            {
                Network = "Facebook",
                DisconnectedImageUrl = "facebook_icon_grey.png",
                ConnectedImageUrl = "facebook_icon_white.png",
                CanConnect = false
            };

            TwitterVM = new SocialServiceViewModel()
            {
                Network = "Twitter",
                DisconnectedImageUrl = "twitter_icon_grey.png",
                ConnectedImageUrl = "twitter_icon_white.png",
                CanConnect = false
            };

            InstagramVM = new SocialServiceViewModel()
            {
                Network = "Instagram",
                DisconnectedImageUrl = "instagram_icon_grey.png",
                ConnectedImageUrl = "instagram_icon_white.png",
                CanConnect = false
            };

            YouTubeVM = new SocialServiceViewModel()
            {
                Network = "YouTube",
                DisconnectedImageUrl = "youtube_icon_grey.png",
                ConnectedImageUrl = "youtube_icon_white.png",
                CanConnect = false
            };

        }

        public void Init()
        {
            if (Model != null)
            {
                Username = Username ?? Model.Username;
                UserEmail = UserEmail ?? Model.Email;
                FirstName = FirstName ?? Model.FirstName;
                LastName = LastName ?? Model.LastName;
            }
        }

        private SocialServiceViewModel _facebookVM;
        public SocialServiceViewModel FacebookVM
        {
            get
            {
                return _facebookVM;
            }
            set
            {
                _facebookVM = value;
                RaisePropertyChanged(nameof(FacebookVM));
            }
        }

        private SocialServiceViewModel _twitterVM;
        public SocialServiceViewModel TwitterVM
        {
            get
            {
                return _twitterVM;
            }
            set
            {
                _twitterVM = value;
                RaisePropertyChanged(nameof(TwitterVM));
            }
        }

        private SocialServiceViewModel _instagramVM;
        public SocialServiceViewModel InstagramVM
        {
            get
            {
                return _instagramVM;
            }
            set
            {
                _instagramVM = value;
                RaisePropertyChanged(nameof(InstagramVM));
            }
        }

        private SocialServiceViewModel _youTubeVM;
        public SocialServiceViewModel YouTubeVM
        {
            get
            {
                return _youTubeVM;
            }
            set
            {
                _youTubeVM = value;
                RaisePropertyChanged(nameof(YouTubeVM));
            }
        }

        public async Task OnSave()
        {
            // TODO implement save
            OnToggleEditMode();
        }

        void InitMockData()
        {
            IsLoggedIn = true;
            Username = "davidortinau";
            UserEmail = "daortin@microsoft.com";
            FirstName = "David";
            LastName = "Ortinau";
            UserPassword = "password";
            ConfirmUserPassword = "password";

        }

        void MockLogout()
        {
            IsLoggedIn = false;
            Username = "";
            UserEmail = "";
            FirstName = "";
            LastName = "";
            UserPassword = "";
            ConfirmUserPassword = "";
        }

        public async Task OnLogout()
        {
            // TODO implement logout
            MockLogout();
        }

        private bool _isEditing;
        public bool IsEditing
        {
            get
            {
                return _isEditing;
            }
            set
            {
                _isEditing = value;
                RaisePropertyChanged(nameof(IsEditing));
                RaisePropertyChanged(nameof(CanSave));
                RaisePropertyChanged(nameof(CanEdit));
                FacebookVM.CanConnect = _isEditing;
                TwitterVM.CanConnect = _isEditing;
                YouTubeVM.CanConnect = _isEditing;
            }
        }

        public bool CanSave
        {
            get
            {
                return _isEditing || !IsLoggedIn;
            }
        }

        public bool CanEdit
        {
            get
            {
                return !_isEditing && IsLoggedIn;
            }
        }

        public async Task OnToggleEditMode()
        {
            IsEditing = !IsEditing;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
