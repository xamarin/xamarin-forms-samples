using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class WindowsListViewPage : ContentPage
    {
        public WindowsListViewPage()
        {
            InitializeComponent();
			BindingContext = new ListViewViewModel();
        }
    }
}
