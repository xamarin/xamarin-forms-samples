using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class AndroidViewCellPage : ContentPage
    {
        public AndroidViewCellPage()
        {
            InitializeComponent();
            BindingContext = new AndroidViewCellPageViewModel();
        }
    }
}
