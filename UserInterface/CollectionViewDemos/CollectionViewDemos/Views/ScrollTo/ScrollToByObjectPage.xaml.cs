using System;
using System.Linq;
using CollectionViewDemos.Models;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class ScrollToByObjectPage : ContentPage
    {
        public ScrollToByObjectPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            MonkeysViewModel viewModel = BindingContext as MonkeysViewModel;
            Monkey monkey = viewModel.Monkeys.FirstOrDefault(m => m.Name == "Proboscis Monkey");
            collectionView.ScrollTo(monkey, position: (ScrollToPosition)enumPicker.SelectedItem, animate: animateSwitch.IsToggled);
        }
    }
}
