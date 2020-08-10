using Xamarin.Forms;
using GridDemos.Converters;

namespace GridDemos.Views
{
    public class ColorSlidersGridPageCS : ContentPage
    {
        BoxView boxView;
        Slider redSlider;
        Slider greenSlider;
        Slider blueSlider;

        public ColorSlidersGridPageCS()
        {
            // Create an implicit style for the Labels
            Style labelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Center }
                }
            };
            Resources.Add(labelStyle);

            // Root page layout
            Grid rootGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition()
                }
            };

            boxView = new BoxView { Color = Color.Black };
            rootGrid.Children.Add(boxView);

            // Child page layout
            Grid childGrid = new Grid
            {
                Margin = new Thickness(20),
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition()
                }
            };

            DoubleToIntConverter doubleToInt = new DoubleToIntConverter();

            redSlider = new Slider();
            redSlider.ValueChanged += OnSliderValueChanged;
            childGrid.Children.Add(redSlider);

            Label redLabel = new Label();
            redLabel.SetBinding(Label.TextProperty, new Binding("Value", converter: doubleToInt, converterParameter: "255", stringFormat: "Red = {0}", source: redSlider));
            Grid.SetRow(redLabel, 1);
            childGrid.Children.Add(redLabel);

            greenSlider = new Slider();
            greenSlider.ValueChanged += OnSliderValueChanged;
            Grid.SetRow(greenSlider, 2);
            childGrid.Children.Add(greenSlider);

            Label greenLabel = new Label();
            greenLabel.SetBinding(Label.TextProperty, new Binding("Value", converter: doubleToInt, converterParameter: "255", stringFormat: "Green = {0}", source: greenSlider));
            Grid.SetRow(greenLabel, 3);
            childGrid.Children.Add(greenLabel);

            blueSlider = new Slider();
            blueSlider.ValueChanged += OnSliderValueChanged;
            Grid.SetRow(blueSlider, 4);
            childGrid.Children.Add(blueSlider);

            Label blueLabel = new Label();
            blueLabel.SetBinding(Label.TextProperty, new Binding("Value", converter: doubleToInt, converterParameter: "255", stringFormat: "Blue = {0}", source: blueSlider));
            Grid.SetRow(blueLabel, 5);
            childGrid.Children.Add(blueLabel);

            // Place the child Grid in the root Grid
            rootGrid.Children.Add(childGrid, 0, 1);

            Title = "Nested Grids demo";
            Content = rootGrid;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            boxView.Color = new Color(redSlider.Value, greenSlider.Value, blueSlider.Value);
        }
    }
}
