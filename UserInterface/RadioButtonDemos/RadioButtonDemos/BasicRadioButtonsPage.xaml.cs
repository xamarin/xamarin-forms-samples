using Xamarin.Forms;

namespace RadioButtonDemos
{
    public partial class BasicRadioButtonsPage : ContentPage
    {
        public BasicRadioButtonsPage()
        {
            InitializeComponent();
        }

        void OnAnimalRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            animalLabel.Text = $"You have chosen: {button.Text}";
        }

        void OnPlatformRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            platformLabel.Text = $"You have chosen: {button.Text}";
        }
    }
}
