using System;
using Xamarin.Forms;

namespace XamlSamples
{
    static class AppConstants
    {
        public static readonly Thickness PagePadding =
            new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0);

        public static readonly Font TitleFont = 
            Font.SystemFontOfSize(Device.OnPlatform(35, 40, 50), FontAttributes.Bold);

        public static readonly Color BackgroundColor =
            Device.OnPlatform(Color.White, Color.Black, Color.Black);

        public static readonly Color ForegroundColor =
            Device.OnPlatform(Color.Black, Color.White, Color.White);
    }
}
