using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkupExtensions
{
    public class HslColorExtension : IMarkupExtension<Color>
    {
        public double H { set; get; }

        public double S { set; get; }

        public double L { set; get; }

        public double A { set; get; } = 1.0;

        public Color ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.FromHsla(H, S, L, A);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Color>).ProvideValue(serviceProvider);
        }
    }
}
