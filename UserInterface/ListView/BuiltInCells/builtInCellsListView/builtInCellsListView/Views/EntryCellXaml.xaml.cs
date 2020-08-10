using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public partial class EntryCellXaml : ContentPage
    {
        public EntryCellXaml()
        {
            InitializeComponent();
            listView.ItemsSource = Constants.Veggies;
        }
    }
}