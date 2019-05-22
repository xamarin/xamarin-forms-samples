using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListVariableSizeItemsPage : ContentPage
    {
        public VerticalListVariableSizeItemsPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
