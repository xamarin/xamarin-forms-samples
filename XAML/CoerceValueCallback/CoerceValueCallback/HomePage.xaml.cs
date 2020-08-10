using Xamarin.Forms;

namespace CoerceValueCallback
{
    public partial class HomePage : ContentPage
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

        public HomePage()
        {
            InitializeComponent();
        }

        static object CoerceAngle(BindableObject bindable, object value)
        {
            var homePage = bindable as HomePage;
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
