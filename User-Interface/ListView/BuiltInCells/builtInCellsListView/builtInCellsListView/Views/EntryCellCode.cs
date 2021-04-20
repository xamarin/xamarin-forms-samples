using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public class EntryCellCode : ContentPage
    {
        public EntryCellCode()
        {
            Padding = 10;
            Title = "EntryCell Code Demo";

            ListView listView = new ListView();
            listView.ItemTemplate = new DataTemplate(typeof(EntryCell));
            listView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "Name");
            listView.ItemTemplate.SetBinding(EntryCell.TextProperty, "Comment");

            listView.ItemsSource = Constants.Veggies;
            Content = listView;
        }
    }
}