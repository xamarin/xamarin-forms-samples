using Xamarin.Forms;
using MonkeyApp.ViewModels;
using MonkeyApp.Models;

namespace MonkeyApp.Views
{
    public partial class MonkeysPage : ContentPage
    {
        public MonkeysPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysPageViewModel();
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var monkey = ((ListView)sender).SelectedItem as Monkey;
            if (monkey != null)
            {
                var page = new MonkeyDetailPage();
                page.BindingContext = monkey;
                await Navigation.PushAsync(page);
            }
        }
    }
}

