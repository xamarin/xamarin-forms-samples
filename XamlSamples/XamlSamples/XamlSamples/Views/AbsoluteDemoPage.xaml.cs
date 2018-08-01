using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Absolute Demo~Explore XAML syntax with AbsoluteLayout")]
    public partial class AbsoluteDemoPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Hello, XAML";
        public static string StatPInfo { get; set; } = "Display a Label with many properties set";

        [System.ComponentModel.Description("Absolute Demo")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Explore XAML syntax with AbsoluteLayout")]
        public string PInfo { get; set; }

        public AbsoluteDemoPage()
        {
            InitializeComponent();
        }
    }
}