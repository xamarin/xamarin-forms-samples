using Xamarin.Forms;

namespace GridDemos.Views
{
    public partial class ColorSlidersGridPage : ContentPage
    {
        public ColorSlidersGridPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
            boxView.Color = new Color(redSlider.Value, greenSlider.Value, blueSlider.Value);
		}
    }
}
