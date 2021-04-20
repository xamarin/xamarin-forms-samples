using Xamarin.Forms;

namespace GridDemos.Views
{
    public class BasicGridPageCS : ContentPage
    {
        public BasicGridPageCS()
        {
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition(),
                    new RowDefinition { Height = new GridLength(100) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };

            // Row 0
            // The BoxView and Label are in row 0 and column 0, and so only needs to be added to the
            // Grid.Children collection to get default row and column settings.
            grid.Children.Add(new BoxView
            {
                Color = Color.Green
            });
            grid.Children.Add(new Label
            {
                Text = "Row 0, Column 0",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            });

            // This BoxView and Label are in row 0 and column 1, which are specified as arguments
            // to the Add method. 
            grid.Children.Add(new BoxView
            {
                Color = Color.Blue
            }, 1, 0);
            grid.Children.Add(new Label
            {
                Text = "Row 0, Column 1",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 0);

            // Row 1
            // This BoxView and Label are in row 1 and column 0, which are specified as arguments
            // to the Add method overload.
            grid.Children.Add(new BoxView
            {
                Color = Color.Teal
            }, 0, 1, 1, 2);
            grid.Children.Add(new Label
            {
                Text = "Row 1, Column 0",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 1, 1, 2); // These arguments indicate that that the child element goes in the column starting at 0 but ending before 1.
                            // They also indicate that the child element goes in the row starting at 1 but ending before 2.

            grid.Children.Add(new BoxView
            {
                Color = Color.Purple
            }, 1, 2, 1, 2);
            grid.Children.Add(new Label
            {
                Text = "Row1, Column 1",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 2, 1, 2);

            // Row 2
            // Alternatively, the BoxView and Label can be positioned in cells with the Grid.SetRow
            // and Grid.SetColumn methods.
            BoxView boxView = new BoxView { Color = Color.Red };
            Grid.SetRow(boxView, 2);
            Grid.SetColumnSpan(boxView, 2);
            Label label = new Label
            {
                Text = "Row 2, Column 0 and 1",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Grid.SetRow(label, 2);
            Grid.SetColumnSpan(label, 2);

            grid.Children.Add(boxView);
            grid.Children.Add(label);

            Title = "Basic Grid demo";
            Content = grid;
        }
    }
}
