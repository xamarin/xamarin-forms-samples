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
            await Shell.Current.GoToAsync($"app://xamarin.com/xaminals/animals/domestic/dogs/dogdetails?name={dogName}");
        }
    }
}
