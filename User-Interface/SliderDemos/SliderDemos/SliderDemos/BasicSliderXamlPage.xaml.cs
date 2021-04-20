using System;
using Xamarin.Forms;

namespace SliderDemos
{
    public partial class BasicSliderXamlPage : ContentPage
    {
        public BasicSliderXamlPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            rotatingLabel.Rotation = value;
            displayLabel.Text = String.Format("The Slider value is {0}", value);
        }
    }
}
