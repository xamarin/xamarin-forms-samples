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
            await Shell.Current.GoToAsync($"app://xamarin.com/xaminals/animals/bears/beardetails?name={bearName}");
        }
    }
}
