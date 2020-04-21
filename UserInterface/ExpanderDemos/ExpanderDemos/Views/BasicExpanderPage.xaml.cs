using System;
using Xamarin.Forms;

namespace ExpanderDemos.Views
{
    public partial class BasicExpanderPage : ContentPage
    {
        public BasicExpanderPage()
        {
            InitializeComponent();
        }

        void OnExpanderTapped(object sender, EventArgs e)
        {
            Console.WriteLine("Expander tapped.");
        }
    }
}
