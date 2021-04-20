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
            animalLabel.Text = $"You have chosen: {button.Content}";
        }

        void OnAnimalImageRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            animalImageLabel.Text = $"You have chosen: {button.Value}";
        }
    }
}
