using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class HorizontalGridSpacingPage : ContentPage
    {
        public HorizontalGridSpacingPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
