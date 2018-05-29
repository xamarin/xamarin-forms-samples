using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public class WindowsListViewPageCS : ContentPage
    {
        public WindowsListViewPageCS()
        {
			var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Xamarin.Forms.Label();
				var ageLabel = new Xamarin.Forms.Label { HorizontalOptions = LayoutOptions.EndAndExpand };

				nameLabel.SetBinding(Xamarin.Forms.Label.TextProperty, "Name");
				ageLabel.SetBinding(Xamarin.Forms.Label.TextProperty, "Age");

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);

                return new ViewCell { View = grid };
            });


            var listView = new Xamarin.Forms.ListView { IsGroupingEnabled = true, ItemTemplate = personDataTemplate };
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "GroupedEmployees");
            listView.GroupDisplayBinding = new Binding("Key");
			listView.On<Windows>().SetSelectionMode(ListViewSelectionMode.Inaccessible);

            Title = "ListView Selection Mode";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { listView }
            };
			BindingContext = new ListViewViewModel();
        }
    }
}
