using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("One-Shot DateTime~Obtain the current DateTime and display it")]
    public partial class OneShotDateTimePage : ContentPage
    {
        public static string StatPTitle { get; set; } = "One-Shot DateTime";
        public static string StatPInfo { get; set; } = "Obtain the current DateTime and display it";

        [System.ComponentModel.Description("One-Shot DateTime")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Obtain the current DateTime and display it")]
        public string PInfo { get; set; }

        public OneShotDateTimePage()
        {
            InitializeComponent();
        }
    }
}