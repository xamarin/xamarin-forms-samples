using Xamarin.Forms;

namespace TextSample
{
    public class LabelPageCode : ContentPage
    {
        public LabelPageCode ()
        {
            var layout = new StackLayout{ Padding = new Thickness (5, 10) };

            layout.Children.Add (new Label{ TextColor = Color.FromHex ("#77d065"), Text = "This is a green label." });
            layout.Children.Add (new Label{ Text = "This is a default, non-customized label." });
            layout.Children.Add (new Label{ Text = "This label has a font size of 30.", FontSize = 30 });
            layout.Children.Add (new Label{ Text = "This is bold text.", FontAttributes = FontAttributes.Bold });

            var formattedString = new FormattedString ();
            formattedString.Spans.Add (new Span{ Text = "Red bold, ", ForegroundColor = Color.Red, FontAttributes = FontAttributes.Bold });
            formattedString.Spans.Add (new Span { Text = "default, " });
            formattedString.Spans.Add (new Span { Text = "italic small.", FontAttributes = FontAttributes.Italic, FontSize =  Device.GetNamedSize(NamedSize.Small, typeof(Label)) });

            layout.Children.Add (new Label { FormattedText = formattedString });

            this.Title = "Label Demo - Code";
            this.Content = layout;
        }
    }
}
