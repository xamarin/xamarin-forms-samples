using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListSwipeContextItemsPage : ContentPage
    {
        public VerticalListSwipeContextItemsPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();            
        }
    }
}
