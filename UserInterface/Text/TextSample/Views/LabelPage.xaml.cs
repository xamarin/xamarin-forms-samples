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
	}
}
