using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
    /// <summary>
    /// For custom renderer on Android (only)
    /// </summary>
    public class ListButton : Button { }


    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var label1 = new Label
            {
                Text = "Label 1",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            label1.SetBinding(Label.TextProperty, new Binding("."));

            var label2 = new Label
            {
                Text = "Label 2",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };

            var button = new ListButton
            {
                Text = "X",
                BackgroundColor = Color.Gray,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            button.SetBinding(Button.CommandParameterProperty, new Binding("."));
            button.Clicked += (sender, e) =>
            {
                var b = (Button)sender;
                var t = b.CommandParameter;
                ((ContentPage)((ListView)((StackLayout)b.Parent).Parent).Parent).DisplayAlert("Clicked", t + " button was clicked", "OK");
                Debug.WriteLine("clicked" + t);
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(15, 5, 5, 15),
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Vertical,
                        Children = { label1, label2 }
                    },
                    button
                }
            };
        }
    }
}

