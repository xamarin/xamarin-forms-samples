using Xamarin.Forms;

namespace RadioButtonDemos
{
    public partial class RadioButtonControlTemplatePage : ContentPage
    {
        public RadioButtonControlTemplatePage()
        {
            InitializeComponent();
        }


        void OnAnimalRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            animalLabel.Text = $"You have chosen: {button.Value}";
        }
    }
}
