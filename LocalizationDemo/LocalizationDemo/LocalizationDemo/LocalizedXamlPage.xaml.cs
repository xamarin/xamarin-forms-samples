using System.Globalization;
using Xamarin.Forms;

namespace LocalizationDemo
{
    public partial class LocalizedXamlPage : ContentPage
    {
        public LocalizedXamlPage()
        {
            // Note: you can override the CurrentUICulture to test other languages
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("zh-Hans");

            InitializeComponent();
        }
    }
}