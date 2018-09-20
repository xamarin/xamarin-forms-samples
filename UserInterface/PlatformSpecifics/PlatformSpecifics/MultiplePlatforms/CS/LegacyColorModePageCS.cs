using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class LegacyColorModePageCS : ContentPage
    {
		Xamarin.Forms.Button _defaultColorModeButton, _legacyColorModeDisabledButton;

        public LegacyColorModePageCS()
        {
			_defaultColorModeButton = new Xamarin.Forms.Button { Text = "Button", TextColor = Color.Blue, BackgroundColor = Color.Bisque };
			var defaultIsEnabledButton = new Xamarin.Forms.Button { Text = "Toggle IsEnabled" };
			defaultIsEnabledButton.Clicked += (sender, e) => 
			{
				var button = sender as Xamarin.Forms.Button;
                ToggleIsEnabled(_defaultColorModeButton, button);
			};

			_legacyColorModeDisabledButton = new Xamarin.Forms.Button { Text = "Button", TextColor = Color.Blue, BackgroundColor = Color.Bisque };
			_legacyColorModeDisabledButton.On<iOS>().SetIsLegacyColorModeEnabled(false);
			_legacyColorModeDisabledButton.On<Android>().SetIsLegacyColorModeEnabled(false);

			var legacyColorModeDisabledIsEnabledButton = new Xamarin.Forms.Button { Text = "Toggle IsEnabled" };
			legacyColorModeDisabledIsEnabledButton.Clicked += (sender, e) => 
			{
				var button = sender as Xamarin.Forms.Button;
				ToggleIsEnabled(_legacyColorModeDisabledButton, button);
			};

			Title = "Legacy Color Mode";
			Content = new StackLayout
			{
				Margin = new Thickness(20),
				Children = 
				{
					new Xamarin.Forms.Label { Text = "The Button below uses the legacy color mode. When IsEnabled is false, it uses the default native colors for the control." },
					_defaultColorModeButton,
					defaultIsEnabledButton,
					new Xamarin.Forms.Label { Text= "The Button below has the legacy color mode disabled. It will use whatever colors are manually set." },
					_legacyColorModeDisabledButton,
					legacyColorModeDisabledIsEnabledButton
                }
            };
        }

        void ToggleIsEnabled(Xamarin.Forms.Button button, Xamarin.Forms.Button toggleButton)
        {
        	button.IsEnabled = !button.IsEnabled;
        	if (toggleButton != null)
        	{
        		toggleButton.Text = $"Toggle IsEnabled (Currently: {button.IsEnabled})";
        	}
        }   
	}
}
              