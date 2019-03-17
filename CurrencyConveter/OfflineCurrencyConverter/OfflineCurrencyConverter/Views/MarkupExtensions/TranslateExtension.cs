using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OfflineCurrencyConverter.Shared;

namespace OfflineCurrencyConverter.Views.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }
        protected Func<string, string> _aditionalCheck = (x) => x;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;

            var text = Text.Translate();

            text = _aditionalCheck?.Invoke(text);

            return text;
        }
    }
}
