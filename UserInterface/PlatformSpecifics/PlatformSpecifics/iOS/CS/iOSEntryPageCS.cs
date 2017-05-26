using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
	public class iOSEntryPageCS : ContentPage
	{
		public iOSEntryPageCS()
		{
			var entry = new Xamarin.Forms.Entry { Placeholder = "Enter text here to see the font size change", FontSize = 22 };
			entry.On<iOS>().EnableAdjustsFontSizeToFitWidth();
			var button = new Button { Text = "Toggle AdjustsFontSizeToFitWidth" };
			button.Clicked += (sender, e) =>
			{
				entry.On<iOS>().SetAdjustsFontSizeToFitWidth(!entry.On<iOS>().AdjustsFontSizeToFitWidth());
			};

			Title = "AdjustsFontSizeToFitWidth";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = { entry, button }
			};
		}
	}
}
