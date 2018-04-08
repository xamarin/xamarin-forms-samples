using System;
using Xamarin.Forms;

namespace FormsGallery.XamlExamples
{
    public partial class ButtonDemoPage : ContentPage
    {
        static int clickTotal;

        public ButtonDemoPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            clickTotal += 1;
            label.Text = String.Format("{0} button click{1}",
                                       clickTotal, clickTotal == 1 ? "" : "s");
        }
    }
}