using Xamarin.Forms;

namespace ValidationCallback
{
	public partial class HomePage : ContentPage
	{
		public static readonly BindableProperty AngleProperty = BindableProperty.Create ("Angle", typeof(double), typeof(HomePage), 0.0, validateValue: IsValidValue);

		public double Angle {
			get { return (double)GetValue (AngleProperty); }
			set{
				try{
					SetValue(AngleProperty, value);
				}
				catch{
					DisplayAlert("Alert", "Angle must be between 0-360", "OK");
				}

			}
		}

		public HomePage ()
		{
			InitializeComponent ();
		}

		static bool IsValidValue (BindableObject view, object value)
		{
			double result;
			bool isDouble = double.TryParse (value.ToString (), out result);
			return (result >= 0 && result <= 360);
		}
	}
}

