using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace TextSample
{
	public partial class LabelPage : ContentPage
	{
        public ICommand TapCommand { get; private set; }

		public LabelPage ()
		{
			InitializeComponent ();
            TapCommand = new Command(async () => await DisplayAlert("Tapped", "This is a tapped Span.", "OK"));
            BindingContext = this;
		}

        void OnLineHeightChanged(object sender, TextChangedEventArgs args)
        {
            var lineHeight = ((Entry)sender).Text;
            try
            {
                _lineHeightLabel.LineHeight = double.Parse(lineHeight);
            }
            catch (FormatException ex)
            {
                Debug.WriteLine($"Can't parse {lineHeight}. {ex.Message}");
            }
        }
	}
}
