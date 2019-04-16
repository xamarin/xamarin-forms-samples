using System.Linq;
using Xamarin.Forms;
using Xaminals.Models;

namespace Xaminals.Views
{
    public partial class MonkeysPage : ContentPage
    {
        public MonkeysPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string monkeyName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            await Shell.Current.GoToAsync($"app://xamarin.com/xaminals/animals/monkeys/monkeydetails?name={monkeyName}");
        }
    }
}
