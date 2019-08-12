using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListHeaderFooterViewPage : ContentPage
    {
        public VerticalListHeaderFooterViewPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
