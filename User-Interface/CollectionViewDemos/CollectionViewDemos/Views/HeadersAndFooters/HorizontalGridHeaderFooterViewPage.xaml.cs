using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class HorizontalGridHeaderFooterViewPage : ContentPage
    {
        public HorizontalGridHeaderFooterViewPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
