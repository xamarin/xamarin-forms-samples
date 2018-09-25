using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public class WindowsListViewPageCS : ContentPage
    {
        Xamarin.Forms.ListView _listView;
        Xamarin.Forms.Label _label;

        public WindowsListViewPageCS()
        {
			var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Xamarin.Forms.Label();
				var ageLabel = new Xamarin.Forms.Label { HorizontalOptions = LayoutOptions.Center };

				nameLabel.SetBinding(Xamarin.Forms.Label.TextProperty, "Name");
				ageLabel.SetBinding(Xamarin.Forms.Label.TextProperty, "Age");

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (sender, e) =>
                {
                    await DisplayAlert("Tap Gesture Recognizer", "Tapped event fired.", "OK");
                };
                nameLabel.GestureRecognizers.Add(tapGestureRecognizer);

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);

                return new ViewCell { View = grid };
            });

            _listView = new Xamarin.Forms.ListView { IsGroupingEnabled = true, ItemTemplate = personDataTemplate };
            _listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "GroupedEmployees");
            _listView.GroupDisplayBinding = new Binding("Key");
            _listView.ItemTapped += async (sender, e) =>
            {
                await DisplayAlert("Item Tapped", "ItemTapped event fired.", "OK");
            };
            _listView.On<Windows>().SetSelectionMode(Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Inaccessible);

            var button = new Button { Text = "Toggle SelectionMode" };
            button.Clicked += (sender, e) =>
            {
                switch (_listView.On<Windows>().GetSelectionMode())
                {
                    case Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Accessible:
                        _listView.On<Windows>().SetSelectionMode(Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Inaccessible);
                        break;
                    case Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Inaccessible:
                        _listView.On<Windows>().SetSelectionMode(Xamarin.Forms.PlatformConfiguration.WindowsSpecific.ListViewSelectionMode.Accessible);
                        break;
                }
                UpdateLabel();
            };

            _label = new Xamarin.Forms.Label { HorizontalOptions = LayoutOptions.Center };

            Title = "ListView Selection Mode";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { _listView, button, _label }
            };
			BindingContext = new ListViewViewModel();
            UpdateLabel();
        }

        void UpdateLabel()
        {
            _label.Text = $"ListView SelectionMode: {_listView.On<Windows>().GetSelectionMode()}";
        }
    }
}
