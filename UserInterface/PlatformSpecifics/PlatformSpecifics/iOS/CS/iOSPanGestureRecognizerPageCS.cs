using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSPanGestureRecognizerPageCS : ContentPage
    {
        public iOSPanGestureRecognizerPageCS()
        {
            Xamarin.Forms.Application.Current.On<iOS>().SetPanGestureRecognizerShouldRecognizeSimultaneously(true);
                
            var messageLabel = new Label { Text = "Scroll the list. If you touch the age Label, this Label will change", FontAttributes = FontAttributes.Bold };
            var toggleButton = new Button { Text = "Toggle Simultaneous Gesture Recognition" };
            toggleButton.Clicked += (sender, e) => 
                Xamarin.Forms.Application.Current.On<iOS>().SetPanGestureRecognizerShouldRecognizeSimultaneously(
                    !Xamarin.Forms.Application.Current.On<iOS>().GetPanGestureRecognizerShouldRecognizeSimultaneously());

            var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                var ageLabel = new Label { HorizontalOptions = LayoutOptions.End };
                ageLabel.SetBinding(Label.TextProperty, "Age");
                var panGestureRecognizer = new PanGestureRecognizer();
                panGestureRecognizer.PanUpdated += (sender, e) => messageLabel.Text = $"panned x:{e.TotalX} y:{e.TotalY}";;
                ageLabel.GestureRecognizers.Add(panGestureRecognizer);

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel, 1, 0);

                return new ViewCell { View = grid };
            });

            var listView = new Xamarin.Forms.ListView { IsGroupingEnabled = true, ItemTemplate = personDataTemplate };
            listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "GroupedEmployees");
            listView.GroupDisplayBinding = new Binding("Key");

            Title = "Pan Gesture Recognizer";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = { messageLabel, toggleButton, listView }
            };
            BindingContext = new ListViewViewModel();
        }
    }
}
