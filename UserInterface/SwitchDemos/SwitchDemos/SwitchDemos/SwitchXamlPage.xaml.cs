using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwitchDemos
{
    public partial class SwitchXamlPage : ContentPage
    {
        public SwitchXamlPage()
        {
            InitializeComponent();
        }

        private void XAMLSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            string stateName = e.Value ? "ON" : "OFF";
            switchStateLabel.Text = $"The switch is {stateName}";
        }
    }
}