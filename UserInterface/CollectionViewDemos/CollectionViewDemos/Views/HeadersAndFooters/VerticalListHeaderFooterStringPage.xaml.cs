using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListHeaderFooterStringPage : ContentPage
    {
        public VerticalListHeaderFooterStringPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
