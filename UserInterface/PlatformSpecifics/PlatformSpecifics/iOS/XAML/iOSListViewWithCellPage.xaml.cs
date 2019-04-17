using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class iOSListViewWithCellPage : ContentPage
    {
        public iOSListViewWithCellPage()
        {
            InitializeComponent();
            BindingContext = new ListViewViewModel(20);
        }
    }
}
