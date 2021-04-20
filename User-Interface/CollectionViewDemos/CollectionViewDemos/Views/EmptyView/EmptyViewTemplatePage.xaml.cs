using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class EmptyViewTemplatePage : ContentPage
    {
        public EmptyViewTemplatePage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }
    }
}
