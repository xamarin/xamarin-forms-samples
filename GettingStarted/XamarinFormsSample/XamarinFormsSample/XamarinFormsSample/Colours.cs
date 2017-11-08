using Xamarin.Forms;

namespace XamarinFormsSample
{
    public static class Colours
    {
        public static Color DarkText = Color.Black;
        public static Color PositiveBackground = Color.FromRgb(200, 200, 200);
        public static Color NegativeBackground = Color.FromHsla(Color.Red.Hue, 1.0, 0.75);
        public static Color BackgroundGrey = Color.FromRgb(200, 200, 200);
        public static Color PositiveBalance = Color.FromRgb(37, 64, 33);
        public static Color NegativeBalance = Color.FromRgb(159, 15, 51);
        public static Color LightBlue = Color.FromRgb(52, 152, 219);
        public static Color SubTitle = Color.FromRgb(52, 152, 219);

        static Colours()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    PositiveBalance = PositiveBalance.AddLuminosity(0.3);
                    NegativeBalance = NegativeBalance.AddLuminosity(0.3);
                    SubTitle = Color.FromRgb(115, 129, 130);
                    break;
                case Device.UWP:
                case Device.WinRT:
                case Device.WinPhone:
                    PositiveBalance = PositiveBalance.AddLuminosity(0.3);
                    NegativeBalance = NegativeBalance.AddLuminosity(0.3);
                    break;
            }
        }
    }
}
