using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    public class ExpanderDemoPage : ContentPage
    {
        public ExpanderDemoPage()
        {
            Label header = new Label
            {
                Text = "Expander",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Expander expander = new Expander
            {
                Header = new Label
                {
                    Text = "Baboon",
                    FontAttributes = FontAttributes.Bold,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                }
            };

            Grid grid = new Grid
            {
                Padding = new Thickness(10),
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };

            grid.Children.Add(new Image
            {
                Source = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg",
                Aspect = Aspect.AspectFill,
                HeightRequest = 120,
                WidthRequest = 120
            });

            grid.Children.Add(new Label
            {
                Text = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                FontAttributes = FontAttributes.Italic
            }, 1, 0);

            expander.Content = grid;

            // Build the page.
            Title = "Expander Demo";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    header,
                    expander
                }
            };
        }
    }
}







