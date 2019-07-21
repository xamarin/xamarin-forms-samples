using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListRTLPage : ContentPage
    {
        public VerticalListRTLPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
