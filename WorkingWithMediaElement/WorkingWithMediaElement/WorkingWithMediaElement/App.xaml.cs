using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithMediaElement
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental" });

            InitializeComponent();

            MainPage = new NavigationPage(
                            new MainPage()
                       );
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
