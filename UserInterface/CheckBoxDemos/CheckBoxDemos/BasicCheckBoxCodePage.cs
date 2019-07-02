using Xamarin.Forms;

namespace CheckBoxDemos
{
    public class BasicCheckBoxCodePage : ContentPage
    {
        public BasicCheckBoxCodePage()
        {
            Grid grid = new Grid { Margin = new Thickness(20) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.25, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.20, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.35, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.20, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            ScrollView scrollView = new ScrollView();
            Label label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = "Lorem ipsum dolor sit amet, elit rutrum, enim hendrerit augue vitae praesent sed non, lorem aenean quis praesent pede, lacus sodales sed condimentum senectus nunc donec, neque pellentesque curabitur velit eleifend et pulvinar. Dapibus in libero volutpat libero. Condimentum hac nec eget, in aliquet sodales orci duis mauris diam, felis iaculis auctor amet curabitur justo faucibus, voluptate mollis, ipsum arcu in fusce. Felis per commodo tempus, in velit lacinia duis lacinia porttitor volutpat. Praesent eros incidunt. Eros purus arcu in suscipit urna. Condimentum eu, mauris sagittis mauris, augue nulla morbi, vehicula mattis cras vulputate sed. Metus amet, bibendum eget nulla consectetuer. Ipsum eget fusce, sapien aenean a. Sit id pellentesque tincidunt pulvinar ac, justo lacus enim. Consectetuer libero, mi aenean dui rhoncus, rutrum dolor lectus amet, praesent porttitor a varius tempor lorem et. Velit at auctor dolore, purus tellus mauris, magna eu ac erat orci ridiculus, leo luctus ultricies sapien in purus ipsum."
            };
            scrollView.Content = label;

            Label italicLabel = new Label { Text = "Italic:", VerticalOptions = LayoutOptions.Center };
            Label boldLabel = new Label { Text = "Bold:", VerticalOptions = LayoutOptions.Center };
            Label underlineLabel = new Label { Text = "Underline:", VerticalOptions = LayoutOptions.Center };
            Label strikethroughLabel = new Label { Text = "Strikethrough:", VerticalOptions = LayoutOptions.Center };
            CheckBox italicCheckBox = new CheckBox { VerticalOptions = LayoutOptions.Center };
            italicCheckBox.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    label.FontAttributes |= FontAttributes.Italic;
                }
                else
                {
                    label.FontAttributes &= ~FontAttributes.Italic;
                }
            };

            CheckBox boldCheckBox = new CheckBox { Color = Color.Red, VerticalOptions = LayoutOptions.Center };
            boldCheckBox.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    label.FontAttributes |= FontAttributes.Bold;
                }
                else
                {
                    label.FontAttributes &= ~FontAttributes.Bold;
                }
            };

            CheckBox underlineCheckBox = new CheckBox { Color = Color.Green, VerticalOptions = LayoutOptions.Center };
            underlineCheckBox.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    label.TextDecorations |= TextDecorations.Underline;
                }
                else
                {
                    label.TextDecorations &= ~TextDecorations.Underline;
                }
            };

            CheckBox strikethroughCheckBox = new CheckBox { Color = Color.Blue, VerticalOptions = LayoutOptions.Center };
            strikethroughCheckBox.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    label.TextDecorations |= TextDecorations.Strikethrough;
                }
                else
                {
                    label.TextDecorations &= ~TextDecorations.Strikethrough;
                }
            };

            grid.Children.Add(italicLabel, 0, 0);
            grid.Children.Add(italicCheckBox, 1, 0);
            grid.Children.Add(boldLabel, 2, 0);
            grid.Children.Add(boldCheckBox, 3, 0);
            grid.Children.Add(underlineLabel, 0, 1);
            grid.Children.Add(underlineCheckBox, 1, 1);
            grid.Children.Add(strikethroughLabel, 2, 1);
            grid.Children.Add(strikethroughCheckBox, 3, 1);
            grid.Children.Add(scrollView, 0, 2);
            Grid.SetColumnSpan(scrollView, 4);

            Title = "Basic CheckBox (Code)";
            Content = grid;
        }
    }
}

