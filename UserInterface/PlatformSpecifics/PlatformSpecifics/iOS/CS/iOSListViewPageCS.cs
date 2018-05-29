using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSListViewPageCS : ContentPage
    {
        public iOSListViewPageCS()
        {
			var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label();
                var ageLabel = new Label { HorizontalOptions = LayoutOptions.End };

                nameLabel.SetBinding(Label.TextProperty, "Name");
                ageLabel.SetBinding(Label.TextProperty, "Age");

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);

                return new ViewCell { View = grid };
            });

            var listView = new Xamarin.Forms.ListView { IsGroupingEnabled = true, ItemTemplate = personDataTemplate };
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "GroupedEmployees");
            listView.GroupDisplayBinding = new Binding("Key");
			listView.On<iOS>().SetSeparatorStyle(SeparatorStyle.FullWidth);

			Title = "ListView FullWidth Separators";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
				Children = { listView }
            };
            BindingContext = new ListViewViewModel();
        }
    }
}
