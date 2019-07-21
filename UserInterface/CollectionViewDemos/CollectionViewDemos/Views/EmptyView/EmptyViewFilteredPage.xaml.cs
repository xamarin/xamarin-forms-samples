using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class EmptyViewFilteredPage : ContentPage
    {
        public EmptyViewFilteredPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
