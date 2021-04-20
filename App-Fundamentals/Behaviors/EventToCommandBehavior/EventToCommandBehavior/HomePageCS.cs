using Xamarin.Forms;

namespace EventToCommandBehavior
{
    public class HomePageCS : ContentPage
    {
        public HomePageCS()
        {
            BindingContext = new HomePageViewModel();

            var listView = new ListView();
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "People");
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Name");
                return textCell;
            });
            listView.Behaviors.Add(new EventToCommandBehavior
            {
                EventName = "ItemSelected",
                Command = ((HomePageViewModel)BindingContext).OutputAgeCommand,
                Converter = new SelectedItemEventArgsToSelectedItemConverter()
            });

            var selectedItemLabel = new Label();
            selectedItemLabel.SetBinding(Label.TextProperty, "SelectedItemText");

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new Label {
                        Text = "Behaviors Demo",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    listView,
                    selectedItemLabel
                }
            };
        }
    }
}
