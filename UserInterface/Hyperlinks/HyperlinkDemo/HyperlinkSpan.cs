using System;
using Xamarin.Forms;

namespace HyperlinkDemo
{
    public class HyperlinkSpan : Span
    {
        public static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkSpan), null);

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public HyperlinkSpan()
        {
            TextDecorations = TextDecorations.Underline;
            TextColor = Color.Blue;
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Device.OpenUri(new Uri(Url)))
            });
        }
    }
}
