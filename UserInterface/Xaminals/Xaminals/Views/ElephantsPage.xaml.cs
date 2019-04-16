using System.Linq;
using Xamarin.Forms;
using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class ElephantsPage : ContentPage
    {
        public ElephantsPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string elephantName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/xaminals/animals/elephants/elephantdetails?name={elephantName}");
        }
    }
}
