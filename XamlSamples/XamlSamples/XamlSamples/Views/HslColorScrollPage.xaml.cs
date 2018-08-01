using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("HSL Color Scroll~Use a view model to select HSL colors")]
    public partial class HslColorScrollPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "HSL Color Scroll";
        public static string StatPInfo { get; set; } = "Use a view model to select HSL colors";

        [System.ComponentModel.Description("HSL Color Scroll")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Use a view model to select HSL colors")]
        public string PInfo { get; set; }

        public HslColorScrollPage()
        {
            InitializeComponent();
        }
    }
}