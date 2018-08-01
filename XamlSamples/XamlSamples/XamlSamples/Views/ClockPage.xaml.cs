using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Clock~Dynamically display the current time")]
     public partial class ClockPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Clock";
        public static string StatPInfo { get; set; } = "Dynamically display the current time";

        [System.ComponentModel.Description("Clock")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Dynamically display the current time")]
        public string PInfo { get; set; }

        public ClockPage()
        {
            InitializeComponent();
        }
    }
}