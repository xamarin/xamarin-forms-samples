using Xamarin.Forms;

namespace DataBindingDemos
{
    public partial class MonkeysPage : ContentPage
    {
        public MonkeysPage()
        {
            InitializeComponent();
            BindingContext = new MonkeysViewModel();
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
                var page = new MonkeyDetailsPage();
                page.BindingContext = monkey;
                await Navigation.PushAsync(page);
            }
        }
    }
}
