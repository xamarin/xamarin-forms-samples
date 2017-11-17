using System;
using Xamarin.Forms;

namespace PlatformSpecifics
{
    public partial class AndroidElevationPage : ContentPage
    {
        public AndroidElevationPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            outputLabel.Text = "The bottom button can receive input, while the top button cannot.";
        }
    }
}
