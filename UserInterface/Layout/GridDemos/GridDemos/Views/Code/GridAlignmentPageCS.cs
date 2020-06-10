using Xamarin.Forms;

namespace GridDemos.Views
{
    public class GridAlignmentPageCS : ContentPage
    {
        public GridAlignmentPageCS()
        {
            Grid grid = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 0,
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition()
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };

            // Row 0
            grid.Children.Add(new BoxView
            {
                Color = Color.AliceBlue
            });
            grid.Children.Add(new Label
            {
                Text = "Upper left",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            });

            grid.Children.Add(new BoxView
            {
                Color = Color.LightSkyBlue
            }, 1, 0);
            grid.Children.Add(new Label
            {
                Text = "Upper center",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            }, 1, 0);

            grid.Children.Add(new BoxView
            {
                Color = Color.CadetBlue
            }, 2, 0);
            grid.Children.Add(new Label
            {
                Text = "Upper right",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start
            }, 2, 0);

            // Row 1
            grid.Children.Add(new BoxView
            {
                Color = Color.CornflowerBlue
            }, 0, 1);
            grid.Children.Add(new Label
            {
                Text = "Center left",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 0, 1);

            grid.Children.Add(new BoxView
            {
                Color = Color.DodgerBlue
            }, 1, 1);
            grid.Children.Add(new Label
            {
                Text = "Center center",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 1, 1);

            grid.Children.Add(new BoxView
            {
                Color = Color.DarkSlateBlue
            }, 2, 1);
            grid.Children.Add(new Label
            {
                Text = "Center right",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            }, 2, 1);

            // Row 2
            grid.Children.Add(new BoxView
            {
                Color = Color.SteelBlue
            }, 0, 2);
            grid.Children.Add(new Label
            {
                Text = "Lower left",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End
            }, 0, 2);

            grid.Children.Add(new BoxView
            {
                Color = Color.LightBlue
            }, 1, 2);
            grid.Children.Add(new Label
            {
                Text = "Lower center",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            }, 1, 2);

            grid.Children.Add(new BoxView
            {
                Color = Color.BlueViolet
            }, 2, 2);
            grid.Children.Add(new Label
            {
                Text = "Lower right",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            }, 2, 2);

            Title = "Grid alignment demo";
            Content = grid;
        }
    }
}
