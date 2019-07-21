using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xaminals.Views
{
    public partial class AboutPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>((url) => Device.OpenUri(new Uri(url)));

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
