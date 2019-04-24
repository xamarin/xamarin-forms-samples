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
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"elephantdetails?name={elephantName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/elephants/elephantdetails?name={elephantName}");
        }
    }
}
