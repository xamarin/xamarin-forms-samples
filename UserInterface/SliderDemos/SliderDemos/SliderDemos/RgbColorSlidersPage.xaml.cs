using System;
using Xamarin.Forms;

namespace SliderDemos
{
    public partial class RgbColorSlidersPage : ContentPage
    {
        public RgbColorSlidersPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == redSlider)
            {
                redLabel.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == greenSlider)
            {
                greenLabel.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            else if (sender == blueSlider)
            {
                blueLabel.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }

            boxView.Color = Color.FromRgb((int)redSlider.Value,
                                          (int)greenSlider.Value,
                                          (int)blueSlider.Value);
        }
    }
}