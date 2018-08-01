using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Slider Transforms~Use Sliders with reverse bindings")]
    public partial class SliderTransformsPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Slider Transforms";
        public static string StatPInfo { get; set; } = "Use Sliders with reverse bindings";

        [System.ComponentModel.Description("Slider Transforms")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Use Sliders with reverse bindings")]
        public string PInfo { get; set; }

        public SliderTransformsPage()
        {
            InitializeComponent();
        }
    }
}