using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Xaml;

namespace DualScreenDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwoTwoPaneView : ContentPage
    {
        public TwoTwoPaneView()
        {
            InitializeComponent();
        }

        private void TwoPaneView_LayoutChanged(object sender, EventArgs e)
        {
            var thing = (TwoPaneView)sender;
            var height = thing.Height;
            var width = thing.Width;
            System.Diagnostics.Debug.WriteLine($"{Device.info.ScaledScreenSize} {thing.Bounds}");
        }
    }
}