using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Duo.Forms.Samples
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Routing.RegisterRoute("CompanionPane", typeof(CompanionPane));
            //Routing.RegisterRoute("DualView", typeof(DualView));
            //Routing.RegisterRoute("ExtendCanvas", typeof(ExtendCanvas));
            //Routing.RegisterRoute("MasterDetail", typeof(MasterDetail));
            //Routing.RegisterRoute("TwoPage", typeof(TwoPage));

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
