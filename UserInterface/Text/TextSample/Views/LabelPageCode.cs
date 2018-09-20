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
            layout.Children.Add (new Label{ Text = "This label has its line height set.", LineHeight = 2.5 });

            var formattedString = new FormattedString ();
            formattedString.Spans.Add (new Span{ Text = "Red bold, ", ForegroundColor = Color.Red, FontAttributes = FontAttributes.Bold, LineHeight = 1.8 });

            var span = new Span { Text = "default, " };
            span.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(async () => await DisplayAlert("Tapped", "This is a tapped Span.", "OK")) });
            formattedString.Spans.Add(span);

            formattedString.Spans.Add (new Span { Text = "italic small.", FontAttributes = FontAttributes.Italic, FontSize =  Device.GetNamedSize(NamedSize.Small, typeof(Label)) });

            layout.Children.Add (new Label { FormattedText = formattedString });

            this.Title = "Label Demo - Code";
            this.Content = layout;
        }
    }
}
