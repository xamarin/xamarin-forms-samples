using Xamarin.Forms;

namespace builtInCellsListView.Views
{
    public class SwitchCellCode : ContentPage
    {
        public SwitchCellCode()
        {
            Padding = 10;
            Title = "SwitchCell Code Demo";

            ListView listView = new ListView();
            listView.ItemTemplate = new DataTemplate(typeof(SwitchCell));
            listView.ItemTemplate.SetBinding(SwitchCell.TextProperty, "Name");
            listView.ItemTemplate.SetBinding(SwitchCell.OnProperty, "IsAVeggie");

            listView.ItemsSource = Constants.Veggies;
            Content = listView;
        }
    }
}