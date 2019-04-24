using System.Linq;
using Xamarin.Forms;
using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class DogsPage : ContentPage
    {
        public DogsPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string dogName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"dogdetails?name={dogName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/dogs/dogdetails?name={dogName}");
        }
    }
}
