using Xamarin.Forms;

namespace LayoutCompression
{
    public partial class ConnectSocialButton : ContentView
    {
        public ConnectSocialButton()
        {
            InitializeComponent();
            BindingContext = new SocialServiceViewModel
            {
                Network = "Facebook",
                DisconnectedImageUrl = "facebook_icon_grey.png",
                ConnectedImageUrl = "facebook_icon_white.png",
                CanConnect = false
            };
        }
    }
}
