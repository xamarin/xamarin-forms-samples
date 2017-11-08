using System;

// forums question
// http://forums.xamarin.com/discussion/17278/custom-font-in-xamarin-forms-font-awesome#latest

// custom fonts in iOS
// http://blog.xamarin.com/custom-fonts-in-ios/

// open-source font download
// https://www.google.com/fonts

using Xamarin.Forms;

namespace WorkingWithFonts
{
    /// <summary>
    /// Using fonts in Xamarin.Forms 1.3 is slightly different to earlier versions.
    /// The 'Font' property has been replaced with three separate properties:
    /// - FontFamily
    /// - FontSize
    /// - FontAttributes
    /// Use these three properties directly and avoid using the Font class.
    /// </summary>
    public class FontPageCs : ContentPage
    {
        public FontPageCs()
        {
            var label = new Label
            {
                Text = "Hello, Xamarin.Forms!",
                FontFamily = Device.RuntimePlatform == Device.iOS ? "Lobster-Regular" :
                                   Device.RuntimePlatform == Device.Android ? "Lobster-Regular.ttf#Lobster-Regular" : "Assets/Fonts/Lobster-Regular.ttf#Lobster",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,

            };
            label.FontSize = Device.RuntimePlatform == Device.iOS ? 24 :
                Device.RuntimePlatform == Device.Android ? Device.GetNamedSize(NamedSize.Medium, label) : Device.GetNamedSize(NamedSize.Large, label);

            var labelBold = new Label
            {
                Text = "Bold",
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            var labelItalic = new Label
            {
                Text = "Italic",
                FontSize = 14,
                FontAttributes = FontAttributes.Italic,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            var labelBoldItalic = new Label
            {
                Text = "BoldItalic",
                FontSize = 14,
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            // Span formatting support
            var labelFormatted = new Label();
            var fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Red, ", ForegroundColor = Color.Red, FontSize = 20, FontAttributes = FontAttributes.Italic });
            fs.Spans.Add(new Span { Text = " blue, ", ForegroundColor = Color.Blue, FontSize = 32 });
            fs.Spans.Add(new Span { Text = " and green!", ForegroundColor = Color.Green, FontSize = 12 });
            labelFormatted.FormattedText = fs;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    label, labelBold, labelItalic, labelBoldItalic, labelFormatted
                }
            };
        }
    }
}

