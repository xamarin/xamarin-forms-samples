using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Relative Layout~Explore XAML markup extensions")]
    public partial class RelativeLayoutPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Relative Layout";
        public static string StatPInfo { get; set; } = "Explore XAML markup extensions";

        [System.ComponentModel.Description("Relative Layout")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Explore XAML markup extensions")]
        public string PInfo { get; set; }

        public RelativeLayoutPage()
        {
            InitializeComponent();
        }
    }
}