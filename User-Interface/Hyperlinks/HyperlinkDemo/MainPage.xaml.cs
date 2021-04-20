using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HyperlinkDemo
{
    public partial class MainPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
