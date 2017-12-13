using Xamarin.Forms;

namespace LayoutCompression
{
    public partial class LayoutCompressionPage : ContentPage
    {
        public LayoutCompressionPage()
        {
            InitializeComponent();
            BindingContext = new UserProfileViewModel();
        }
    }
}
