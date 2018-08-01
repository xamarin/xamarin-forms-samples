using System;
using Xamarin.Forms;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("XAML + Code~Interact with a Slider and Button")]
    public partial class XamlPlusCodePage
    {       
        public static string StatPTitle { get; set; } = "XAML + Code";
        public static string StatPInfo { get; set; } = "Interact with a Slider and Button";

        [System.ComponentModel.Description("XAML + Code")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Interact with a Slider and Button")]
        public string PInfo { get; set; }

        public XamlPlusCodePage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, 
                                  ValueChangedEventArgs args)
        {
            valueLabel.Text = args.NewValue.ToString("F3");
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }
    }
}
