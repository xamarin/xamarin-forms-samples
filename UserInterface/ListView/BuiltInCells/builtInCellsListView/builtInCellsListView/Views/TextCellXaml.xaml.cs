using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public partial class TextCellXaml : ContentPage
    {
        public TextCellXaml()
        {
            InitializeComponent();
            listView.ItemsSource = Constants.Veggies;
        }
    }
}