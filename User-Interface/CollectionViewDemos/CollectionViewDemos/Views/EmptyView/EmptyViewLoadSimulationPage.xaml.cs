using System.Threading.Tasks;
using CollectionViewDemos.ViewModels;
using Xamarin.Forms;

namespace CollectionViewDemos.Views
{
    public partial class EmptyViewLoadSimulationPage : ContentPage
    {
        public EmptyViewLoadSimulationPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(2000);
            collectionView.ItemsSource = (BindingContext as MonkeysViewModel).Monkeys;
        }
    }
}
