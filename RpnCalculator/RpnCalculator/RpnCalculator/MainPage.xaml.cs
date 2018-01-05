using System;
using Xamarin.Forms;

namespace RpnCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SizeChanged += (sender, args) =>
            {
                bool isLandscape = Width > Height;
                portrait.IsVisible = portrait.IsEnabled = !isLandscape;
                landscape.IsVisible = landscape.IsEnabled = isLandscape;
            };

        }
    }
}
