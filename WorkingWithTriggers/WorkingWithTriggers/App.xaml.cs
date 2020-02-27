using Xamarin.Forms;

namespace WorkingWithTriggers
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "StateTriggers_Experimental" });
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
