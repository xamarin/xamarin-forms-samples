using System.Linq;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class VerticalListMultiplePreSelectionPage : ContentPage
    {
        public VerticalListMultiplePreSelectionPage()
        {
            InitializeComponent();

            MonkeysViewModel viewModel = new MonkeysViewModel();
            BindingContext = viewModel;

            collectionView.SelectedItems.Add(viewModel.Monkeys.Skip(1).FirstOrDefault());
            collectionView.SelectedItems.Add(viewModel.Monkeys.Skip(3).FirstOrDefault());
            collectionView.SelectedItems.Add(viewModel.Monkeys.Skip(4).FirstOrDefault());
        }
    }
}
