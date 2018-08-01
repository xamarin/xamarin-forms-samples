using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Hello Xaml~Display a Label with many properties set")]
    public partial class HelloXamlPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Hello, XAML";
        public static string StatPInfo { get; set; } = "Display a Label with many properties set";

        [System.ComponentModel.Description("Hello, XAML")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Display a Label with many properties set")]
        public string PInfo { get; set; }

        public HelloXamlPage()
        {
            InitializeComponent();
        }
    }
}