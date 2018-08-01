using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Static Constants~Using the x:Static markup extensions")]
    public partial class StaticConstantsPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Static Constants";
        public static string StatPInfo { get; set; } = "Using the x:Static markup extensions";


        [System.ComponentModel.Description("Static Constants")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Using the x:Static markup extensions")]
        public string PInfo { get; set; }

        public StaticConstantsPage()
        {
            InitializeComponent();
        }
    }
}