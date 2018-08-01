using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("ListView Demo~Use a ListView with data bindings")]
    public partial class ListViewDemoPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "ListView Demo";
        public static string StatPInfo { get; set; } = "Use a ListView with data bindings";

        [System.ComponentModel.Description("ListView Demo")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Use a ListView with data bindings")]
        public string PInfo { get; set; }

        public ListViewDemoPage()
        {
            InitializeComponent();
        }

    }
}