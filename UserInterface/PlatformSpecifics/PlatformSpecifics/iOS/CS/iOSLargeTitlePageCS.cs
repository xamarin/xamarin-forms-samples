using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public class iOSLargeTitlePageCS : ContentPage
    {
        public iOSLargeTitlePageCS(ICommand restore)
        {
            On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
            var toggleButton = new Button { Text = "Toggle Large Title" };
            toggleButton.Clicked += OnToggleButtonClicked;
            var returnButton = new Button { Text = "Return to Platform-Specifics List" };
            returnButton.Clicked += (sender, e) => restore.Execute(null);

            Title = "Large Title";
            Content = new StackLayout
            {
                Margin = new Thickness(0, 40, 0, 0),
                Children = { toggleButton, returnButton }
            };
        }

        void OnToggleButtonClicked(object sender, EventArgs e)
        {
            switch (On<iOS>().LargeTitleDisplay())
            {
                case LargeTitleDisplayMode.Always:
                    On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Automatic);
                    break;
                case LargeTitleDisplayMode.Automatic:
                    On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Never);
                    break;
                case LargeTitleDisplayMode.Never:
                    On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
                    break;
            }
        }
    }
}
