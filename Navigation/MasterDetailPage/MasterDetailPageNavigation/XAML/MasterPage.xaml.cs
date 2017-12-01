using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();
        }
    }
}
