using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HyperlinkDemo
{
    public partial class MainPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(OpenBrowser);

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }
    }
}
