using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Slider Bindings~Bind properties of two views on the page")]
    public partial class SliderBindingsPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Slider Bindings";
        public static string StatPInfo { get; set; } = "Bind properties of two views on the page";

        [System.ComponentModel.Description("Slider Bindings")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Bind properties of two views on the page")]
        public string PInfo { get; set; }

        public SliderBindingsPage()
        {
            InitializeComponent();
        }
    }
}