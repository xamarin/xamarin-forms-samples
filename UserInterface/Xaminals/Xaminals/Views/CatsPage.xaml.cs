using System.Linq;
using Xamarin.Forms;
using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string catName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/xaminals/animals/domestic/cats/catdetails?name={catName}");
        }
    }
}
