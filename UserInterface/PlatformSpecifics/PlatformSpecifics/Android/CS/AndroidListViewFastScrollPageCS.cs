using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidListViewFastScrollPageCS : ContentPage
    {
        public AndroidListViewFastScrollPageCS()
        {
            var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label();
                var ageLabel = new Label { HorizontalOptions = LayoutOptions.EndAndExpand };

                nameLabel.SetBinding(Label.TextProperty, "Name");
                ageLabel.SetBinding(Label.TextProperty, "Age");

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);

                return new ViewCell { View = grid };
            });

            var listView = new Xamarin.Forms.ListView { IsGroupingEnabled = true, ItemTemplate = personDataTemplate };
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "GroupedEmployees");
            listView.GroupDisplayBinding = new Binding("Key");
            listView.On<Android>().SetIsFastScrollEnabled(true);

            var button = new Button { Text = "Toggle FastScroll" };
            button.Clicked += (sender, e) => { listView.On<Android>().SetIsFastScrollEnabled(!listView.On<Android>().IsFastScrollEnabled()); };

            Title = "ListView FastScroll";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    button,
                    listView
                }
            };
            BindingContext = new ListViewViewModel();
        }
    }
}
