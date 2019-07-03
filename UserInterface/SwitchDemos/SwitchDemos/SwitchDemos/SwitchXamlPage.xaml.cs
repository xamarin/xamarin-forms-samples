using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwitchDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchXamlPage : ContentPage
    {
        public SwitchXamlPage()
        {
            InitializeComponent();
        }

        private void XAMLSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            string stateName = e.Value ? "ON" : "OFF";
            SwitchStateLabel.Text = $"The switch is {stateName}";
        }
    }
}