using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class SwitchDemoPage : ContentPage
    {
        Label label;

        public SwitchDemoPage()
        {
            Label header = new Label
            {
                Text = "Switch",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            switcher.Toggled += switcher_Toggled;

            label = new Label
            {
                Text = "Switch is now False",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    switcher,
                    label
                }
            };
        }

        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            label.Text = String.Format("Switch is now {0}", e.Value);
        }
    }
}
