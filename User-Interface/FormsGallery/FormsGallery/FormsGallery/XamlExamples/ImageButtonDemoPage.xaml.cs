using System;
using Xamarin.Forms;

namespace FormsGallery.XamlExamples
{
    public partial class ImageButtonDemoPage : ContentPage
    {
        int clickTotal;

        public ImageButtonDemoPage()
        {
            InitializeComponent();
        }

        void OnImageButtonClicked(object sender, EventArgs e)
        {
            clickTotal += 1;
            label.Text = $"{clickTotal} ImageButton click{(clickTotal == 1 ? "" : "s")}";
        }
    }
}
