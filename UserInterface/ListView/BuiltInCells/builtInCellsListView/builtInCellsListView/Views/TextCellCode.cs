using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public class TextCellCode : ContentPage
    {
        public TextCellCode()
        {
            Padding = 10;
            Title = "TextCell Code Demo";

            ListView listView = new ListView();
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Comment");

            listView.ItemsSource = Constants.Veggies;
            Content = listView;
        }
    }
}