using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListDataTemplateSelectorPage : ContentPage
    {
        public VerticalListDataTemplateSelectorPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
