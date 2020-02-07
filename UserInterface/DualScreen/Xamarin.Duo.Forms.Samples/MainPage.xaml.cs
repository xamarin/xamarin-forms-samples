using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Duo.Forms.Samples
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            twoPaneView.TallModeConfiguration = Xamarin.Forms.DualScreen.TwoPaneViewTallModeConfiguration.TopBottom;
        }

        void OnNavigateToSample(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch(button.Text)
            {
                case "Two Page":
                    Navigation.PushAsync(new TwoPage());
                    break;
                case "Dual View":
                    Navigation.PushAsync(new DualViewListPage());
                    break;
                case "Extend Canvas":
                    Navigation.PushAsync(new ExtendCanvas());
                    break;
                case "Master Detail":
                    Navigation.PushAsync(new MasterDetail());
                    break;
                case "Companion Pane":
                    Navigation.PushAsync(new CompanionPane());
                    break;
                case "Two Two Pane":
                    Navigation.PushAsync(new TwoTwoPaneView());
                    break;

            }
        }
    }
}
