using Xamarin.Forms;

namespace FormsGallery.XamlExamples
{
    public partial class RadioButtonDemoPage : ContentPage
    {
        public RadioButtonDemoPage()
        {
            InitializeComponent();
        }

        void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            colorLabel.Text = $"You have chosen: {button.Text}";
        }

        void OnFruitsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            fruitLabel.Text = $"You have chosen: {button.Text}";
        }
    }
}
