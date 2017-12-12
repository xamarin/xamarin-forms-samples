using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBindingDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwoWayBindingPage : ContentPage
    {
        public TwoWayBindingPage()
        {
            InitializeComponent();


            var x = System.Globalization.CultureInfo.CurrentCulture;

            var z = new System.Globalization.RegionInfo("fr-fr");

            var a = new System.Globalization.CultureInfo("fr-fr");

            var y = x.DateTimeFormat.DayNames[3];
        }
    }
}