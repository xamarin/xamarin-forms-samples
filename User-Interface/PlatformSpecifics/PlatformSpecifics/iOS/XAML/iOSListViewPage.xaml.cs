using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSListViewPage : ContentPage
    {
        public iOSListViewPage()
        {
            InitializeComponent();
			BindingContext = new ListViewViewModel();
        }
    }
}
