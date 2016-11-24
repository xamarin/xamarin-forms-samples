using Xamarin.Forms;

namespace SimpleColorPicker
{
	public partial class SimpleColorPickerPage : ContentPage
	{
		public SimpleColorPickerPage()
		{
			InitializeComponent();
			BindingContext = new SimpleColorPickerPageViewModel { SelectedColor = Color.Red };
		}
	}
}
