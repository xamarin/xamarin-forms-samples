using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public partial class SwitchCellXaml : ContentPage
    {
        public SwitchCellXaml()
        {
            InitializeComponent();
            listView.ItemsSource = Constants.Veggies;
        }
    }
}