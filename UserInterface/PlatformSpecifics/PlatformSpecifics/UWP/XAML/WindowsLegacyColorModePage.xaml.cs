using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class WindowsLegacyColorModePage : ContentPage
    {
        public WindowsLegacyColorModePage()
        {
            InitializeComponent();
        }

		void OnDefaultToggleButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            ToggleIsEnabled(_defaultColorModeEditor, button);
        }

        void OnLegacyColorModeDisabledToggleButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            ToggleIsEnabled(_legacyColorModeDisabledEditor, button);
        }

        void ToggleIsEnabled(Editor editor, Button toggleButton)
        {
            editor.IsEnabled = !editor.IsEnabled;
            if (toggleButton != null)
            {
                toggleButton.Text = $"Toggle IsEnabled (Currently: {editor.IsEnabled})";
            }
        }
    }
}
