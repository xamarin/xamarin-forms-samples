using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Grid Demo~Explore XAML syntax with the Grid")]
    public partial class GridDemoPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Grid Demo";
        public static string StatPInfo { get; set; } = "Explore XAML syntax with the Grid";


        [System.ComponentModel.Description("Grid Demo")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Explore XAML syntax with the Grid")]
        public string PInfo { get; set; }

        public GridDemoPage()
        {
            InitializeComponent();
        }
    }
}