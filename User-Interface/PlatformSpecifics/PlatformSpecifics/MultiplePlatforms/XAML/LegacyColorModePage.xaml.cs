using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class LegacyColorModePage : ContentPage
    {
        public LegacyColorModePage()
        {
            InitializeComponent();
        }

		void OnDefaultToggleButtonClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			ToggleIsEnabled(_defaultColorModeButton, button);
		}

        void OnLegacyColorModeDisabledToggleButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            ToggleIsEnabled(_legacyColorModeDisabledButton, button);
        }

		void ToggleIsEnabled(Button button, Button toggleButton)
		{
			button.IsEnabled = !button.IsEnabled;
			if (toggleButton != null)
			{
				toggleButton.Text = $"Toggle IsEnabled (Currently: {button.IsEnabled})";
			}
		}
    }
}
