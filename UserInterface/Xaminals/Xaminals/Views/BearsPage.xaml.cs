using System.Linq;
using Xamarin.Forms;
using Xaminals.Models;
using Xaminals.ViewModels;

namespace Xaminals.Views
{
    public partial class BearsPage : ContentPage
    {
        public BearsPage()
        {
            InitializeComponent();
            BindingContext = new BearsViewModel();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string bearName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"beardetails?name={bearName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/bears/beardetails?name={bearName}");
        }
    }
}
