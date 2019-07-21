using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace TextSample
{
    public class LabelPageCode : ContentPage
    {
        public LabelPageCode ()
        {
            var layout = new StackLayout{ Padding = new Thickness (5, 10) };

            layout.Children.Add (new Label { TextColor = Color.FromHex ("#77d065"), Text = "This is a green label." });
            layout.Children.Add (new Label { Text = "This is a default, non-customized label." });
            layout.Children.Add (new Label { Text = "This label has a font size of 30.", FontSize = 30 });
            layout.Children.Add (new Label { Text = "This is bold text.", FontAttributes = FontAttributes.Bold });
            layout.Children.Add (new Label { Text = "This is underlined text.", TextDecorations = TextDecorations.Underline });
            layout.Children.Add (new Label { Text = "This is text with strikethrough.", TextDecorations = TextDecorations.Strikethrough });
            layout.Children.Add (new Label { Text = "This is underlined text with strikethrough.", TextDecorations = TextDecorations.Underline | TextDecorations.Strikethrough });

            // Line height
            var lineHeightLabel = new Label { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In facilisis nulla eu felis fringilla vulputate. Nullam porta eleifend lacinia. Donec at iaculis tellus.", LineBreakMode = LineBreakMode.WordWrap, MaxLines=2 };
            var entry = new Entry { Placeholder = "Enter line height" };
            entry.TextChanged += (sender, e) => 
            {
                var lineHeight = ((Entry)sender).Text;
                try
                {
                    lineHeightLabel.LineHeight = double.Parse(lineHeight);
                }
                catch (FormatException ex)
                {
                    Debug.WriteLine($"Can't parse {lineHeight}. {ex.Message}");
                }
            };
            layout.Children.Add(entry);
            layout.Children.Add(lineHeightLabel);

            var formattedString = new FormattedString ();
            formattedString.Spans.Add (new Span{ Text = "Red bold, ", ForegroundColor = Color.Red, FontAttributes = FontAttributes.Bold });
            var span = new Span { Text = "default, " };
            span.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(async () => await DisplayAlert("Tapped", "This is a tapped Span.", "OK")) });
            formattedString.Spans.Add(span);
            formattedString.Spans.Add (new Span { Text = "italic small.", FontAttributes = FontAttributes.Italic, FontSize =  Device.GetNamedSize(NamedSize.Small, typeof(Label)) });
            layout.Children.Add (new Label { FormattedText = formattedString });

            var formattedStringWithLineHeightSet = new FormattedString();
            formattedStringWithLineHeightSet.Spans.Add(new Span { LineHeight = 1.8, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In a tincidunt sem. Phasellus mollis sit amet turpis in rutrum. Sed aliquam ac urna id scelerisque. " });
            formattedStringWithLineHeightSet.Spans.Add(new Span { LineHeight = 1.8, Text = "Nullam feugiat sodales elit, et maximus nibh vulputate id." });
            layout.Children.Add(new Label { FormattedText = formattedStringWithLineHeightSet, LineBreakMode = LineBreakMode.WordWrap });

            this.Title = "Label Demo - Code";
            this.Content = layout;
        }

        void OnLineHeightChanged(object sender, TextChangedEventArgs args)
        {

        }
    }
}
