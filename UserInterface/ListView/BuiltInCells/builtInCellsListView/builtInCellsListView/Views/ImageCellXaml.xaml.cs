using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public partial class ImageCellXaml : ContentPage
    {
        public ImageCellXaml()
        {
            InitializeComponent();
            listView.ItemsSource = Constants.Veggies;
        }
    }
}