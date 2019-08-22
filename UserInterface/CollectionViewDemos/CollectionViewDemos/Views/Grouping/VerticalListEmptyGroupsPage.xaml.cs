using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListEmptyGroupsPage : ContentPage
    {
        public VerticalListEmptyGroupsPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel(true);
        }
    }
}
