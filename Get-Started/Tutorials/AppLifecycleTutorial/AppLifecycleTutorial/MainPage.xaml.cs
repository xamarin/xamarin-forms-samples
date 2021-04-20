using System;
using Xamarin.Forms;

namespace AppLifecycleTutorial
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            entry.Text = (Application.Current as App).DisplayText;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            (Application.Current as App).DisplayText = entry.Text;
        }
    }
}
