using Xamarin.Forms;

namespace CoerceValueCallback
{
    public class HomePageCS : ContentPage
    {
        public static readonly BindableProperty AngleProperty = BindableProperty.Create("Angle", typeof(double), typeof(HomePage), 0.0, coerceValue: CoerceAngle);
        public static readonly BindableProperty MaximumAngleProperty = BindableProperty.Create("MaximumAngle", typeof(double), typeof(HomePage), 360.0, propertyChanged: ForceCoerceValue);

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public double MaximumAngle
        {
            get { return (double)GetValue(MaximumAngleProperty); }
            set { SetValue(MaximumAngleProperty, value); }
        }

        public HomePageCS()
        {
            BindingContext = this;

            var maximumAngleEntry = new Entry { WidthRequest = 50 };
            maximumAngleEntry.SetBinding(Entry.TextProperty, "MaximumAngle");

            var angleEntry = new Entry { WidthRequest = 50 };
            angleEntry.SetBinding(Entry.TextProperty, "Angle");

            var image = new Image { VerticalOptions = LayoutOptions.CenterAndExpand };
            image.Source = ImageSource.FromFile("waterfront.jpg");
            image.SetBinding(VisualElement.RotationProperty, "Angle");

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    new Label {
                        Text = "Bindable Property CoerceValue Callback Demo",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        Children = {
                            new Label { Text = "Maximum angle:" },
                            maximumAngleEntry
                        }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        Children = {
                            new Label { Text = "Maximum angle:" },
                            angleEntry
                        }
                    },
                    image
                }
            };
        }

        static object CoerceAngle(BindableObject bindable, object value)
        {
            var homePage = bindable as HomePageCS;
            double input = (double)value;

            if (input > homePage.MaximumAngle)
            {
                input = homePage.MaximumAngle;
            }

            return input;
        }

        static void ForceCoerceValue(BindableObject bindable, object oldValue, object newValue)
        {
            bindable.CoerceValue(AngleProperty);
        }
    }
}
