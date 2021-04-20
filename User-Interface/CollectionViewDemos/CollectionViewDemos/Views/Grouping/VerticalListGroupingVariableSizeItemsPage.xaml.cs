using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListGroupingVariableSizeItemsPage : ContentPage
    {
        public VerticalListGroupingVariableSizeItemsPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel();
        }
    }
}
