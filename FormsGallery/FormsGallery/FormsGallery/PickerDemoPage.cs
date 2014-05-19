using System;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGallery
{
    class PickerDemoPage : ContentPage
    {
        public PickerDemoPage()
        {
            Label header = new Label
            {
                Text = "Picker",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Picker picker = new Picker
            {
                Title = "Color",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string color in new string[]
                {
                    "Aqua", "Black", "Blue", "Fuschia",
                    "Gray", "Green", "Lime", "Maroon",
                    "Navy", "Olive", "Purple", "Red",
                    "Silver", "Teal", "White", "Yellow"
                })
            {
                picker.Items.Add(color);
            }

            // Create BoxView for displaying pickedColor
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            picker.SelectedIndexChanged += (sender, args) =>
                {
                    if (picker.SelectedIndex == -1)
                    {
                        boxView.Color = Color.Default;
                    }
                    else
                    {
                        string selectedItem = picker.Items[picker.SelectedIndex];
                        FieldInfo colorField = typeof(Color).GetTypeInfo().GetDeclaredField(selectedItem);
                        boxView.Color = (Color)colorField.GetValue(null);
                    }
                };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    picker,
                    boxView
                }
            };

        }
    }
}
