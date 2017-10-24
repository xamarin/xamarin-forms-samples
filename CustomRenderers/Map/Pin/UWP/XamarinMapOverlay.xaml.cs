using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CustomRenderer.UWP
{
    public sealed partial class XamarinMapOverlay : UserControl
    {
        CustomPin customPin;

        public XamarinMapOverlay(CustomPin pin)
        {
            this.InitializeComponent();
            customPin = pin;
            SetupData();   
        }

        void SetupData()
        {
            Label.Text = customPin.Label;
            Address.Text = customPin.Address;
        }

        private async void OnInfoButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(customPin.Url));
        }
    }
}
