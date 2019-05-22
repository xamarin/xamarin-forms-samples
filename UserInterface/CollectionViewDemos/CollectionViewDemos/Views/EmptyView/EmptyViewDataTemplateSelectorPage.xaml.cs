using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class EmptyViewDataTemplateSelectorPage : ContentPage
    {
        public EmptyViewDataTemplateSelectorPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
