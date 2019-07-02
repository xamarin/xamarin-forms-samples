using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListMultiplePreSelectionPage : ContentPage
    {
        public VerticalListMultiplePreSelectionPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
