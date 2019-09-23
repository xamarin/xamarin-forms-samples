using BindingContextChanged.CustomControls;
using Xamarin.Forms;

namespace BindingContextChanged
{
    public class ListPageCS : ContentPage
    {
        public ListPageCS()
        {
            Title = "BindingContextChanged Code Demo";
            Padding = 10;

            var customCell = new DataTemplate(typeof(CustomCell));
            customCell.SetBinding(CustomCell.NameProperty, "Name");
            customCell.SetBinding(CustomCell.AgeProperty, "Age");
            customCell.SetBinding(CustomCell.LocationProperty, "Location");

            var listView = new ListView
            {
                ItemTemplate = customCell
            };

            var button = new Button { Text = "Change Binding Context" };
            button.Clicked += (sender, e) =>
            {
                listView.ItemsSource = Constants.People;
            };

            Content = new StackLayout
            {
                Children = {
                    listView,
                    button
                }
            };
        }
    }
}
