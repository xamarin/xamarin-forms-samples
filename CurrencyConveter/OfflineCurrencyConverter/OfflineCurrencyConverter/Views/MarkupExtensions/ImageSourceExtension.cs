using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfflineCurrencyConverter.Views.MarkupExtensions
{
    [ContentProperty("Source")]
    public class ImageSourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Device.RuntimePlatform == Device.UWP ? 
                    ImageSource.FromFile($"Assets/{Source}") : ImageSource.FromFile(Source);
        }
    }
}
