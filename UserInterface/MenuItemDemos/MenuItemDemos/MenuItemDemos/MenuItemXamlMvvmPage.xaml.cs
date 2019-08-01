using MenuItemDemos.Services;
using MenuItemDemos.ViewModels;

using Xamarin.Forms;

namespace MenuItemDemos
{
    public partial class MenuItemXamlMvvmPage : ContentPage
    {
        public MenuItemXamlMvvmPage()
        {
            InitializeComponent();

            BindingContext = new ListPageViewModel(DataService.GetListItems());
        }
    }
}