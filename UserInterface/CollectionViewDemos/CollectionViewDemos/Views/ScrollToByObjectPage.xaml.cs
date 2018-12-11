using System;
using Xamarin.Forms;
using CollectionViewDemos.ViewModels;
using System.Linq;

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
            var viewModel = BindingContext as MonkeysViewModel;
            var monkey = viewModel.Monkeys.FirstOrDefault(m => m.Name == "Proboscis Monkey");
            _collectionView.ScrollTo(monkey);
        }
    }
}
