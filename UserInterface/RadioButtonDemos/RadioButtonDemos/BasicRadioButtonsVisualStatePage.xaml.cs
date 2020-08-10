using Xamarin.Forms;

namespace RadioButtonDemos
{
    public partial class BasicRadioButtonsVisualStatePage : ContentPage
    {
        public BasicRadioButtonsVisualStatePage()
        {
            InitializeComponent();
        }

        void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            resultLabel.Text = $"You have chosen: {button.Text}";
        }
    }
}
