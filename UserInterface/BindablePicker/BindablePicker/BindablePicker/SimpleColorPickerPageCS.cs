using Xamarin.Forms;

namespace BindablePicker
{
	public class SimpleColorPickerPageCS : ContentPage
	{
		public SimpleColorPickerPageCS()
		{
			var picker = new Picker { Title = "Select a color" };
			picker.SetBinding(Picker.ItemsSourceProperty, "ColorNames");
			picker.SetBinding(Picker.SelectedItemProperty, "SelectedColorName", mode: BindingMode.TwoWay);

			var boxView = new BoxView { HeightRequest = 200 };
			boxView.SetBinding(BoxView.ColorProperty, "SelectedColor");

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = {
					new Label { Text = "Bindable Picker Demo", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
					picker,
					boxView
				}
			};

			BindingContext = new SimpleColorPickerPageViewModel();
		}
	}
}
