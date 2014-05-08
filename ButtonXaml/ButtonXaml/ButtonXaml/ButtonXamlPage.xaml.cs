using System;
using Xamarin.Forms;

namespace ButtonXaml
{
    public partial class ButtonXamlPage
    {
        int count = 0;

        public ButtonXamlPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            count++;

            ((Button)sender).Text = 
                String.Format("{0} click{1}!", count, count == 1 ? "" : "s");
        }
    }
}
