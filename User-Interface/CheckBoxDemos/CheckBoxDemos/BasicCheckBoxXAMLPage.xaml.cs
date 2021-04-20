using Xamarin.Forms;

namespace CheckBoxDemos
{
    public partial class BasicCheckBoxXAMLPage : ContentPage
    {
        public BasicCheckBoxXAMLPage()
        {
            InitializeComponent();
        }

        void OnItalicCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        void OnBoldCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Bold;
            }
        }

        void OnUnderlineCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                label.TextDecorations |= TextDecorations.Underline;
            }
            else
            {
                label.TextDecorations &= ~TextDecorations.Underline;
            }
        }

        void OnStrikethroughCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                label.TextDecorations |= TextDecorations.Strikethrough;
            }
            else
            {
                label.TextDecorations &= ~TextDecorations.Strikethrough;
            }
        }
    }
}
