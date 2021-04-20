using System.Threading.Tasks;
using CarouselViewDemos.ViewModels;
using Xamarin.Forms;

namespace CarouselViewDemos.Views
{
    public partial class EmptyViewLoadSimulationPage : ContentPage
    {
        public EmptyViewLoadSimulationPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(2000);
            carouselView.ItemsSource = (BindingContext as MonkeysViewModel).Monkeys;
        }
    }
}
