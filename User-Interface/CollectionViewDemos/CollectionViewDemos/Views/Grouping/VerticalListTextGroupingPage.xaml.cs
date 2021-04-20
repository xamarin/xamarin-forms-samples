using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListTextGroupingPage : ContentPage
    {
        public VerticalListTextGroupingPage()
        {
            InitializeComponent();
            BindingContext = new GroupedAnimalsViewModel();
        }
    }
}
