using Xamarin.Forms;
using CollectionViewDemos.ViewModels;

namespace CollectionViewDemos.Views
{
    public partial class VerticalGridPage : ContentPage
    {
        public VerticalGridPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
