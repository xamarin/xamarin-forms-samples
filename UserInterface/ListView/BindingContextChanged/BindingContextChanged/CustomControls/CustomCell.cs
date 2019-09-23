using Xamarin.Forms;

namespace BindingContextChanged.CustomControls
{
    public class CustomCell : ViewCell
    {
        Label nameLabel, ageLabel, locationLabel;

        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(CustomCell), "Name");
        public static readonly BindableProperty AgeProperty = BindableProperty.Create("Age", typeof(int), typeof(CustomCell), 0);
        public static readonly BindableProperty LocationProperty = BindableProperty.Create("Location", typeof(string), typeof(CustomCell), "Location");

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public string Location
        {
            get { return (string)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        public CustomCell()
        {
            var grid = new Grid { Padding = new Thickness(10) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

            nameLabel = new Label { FontAttributes = FontAttributes.Bold };
            ageLabel = new Label();
            locationLabel = new Label { HorizontalTextAlignment = TextAlignment.End };

            grid.Children.Add(nameLabel);
            grid.Children.Add(ageLabel, 1, 0);
            grid.Children.Add(locationLabel, 2, 0);

            View = grid;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                nameLabel.Text = Name;
                ageLabel.Text = Age.ToString();
                locationLabel.Text = Location;
            }
        }
    }
}
