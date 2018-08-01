using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Shared Resources~Using resource dictionaries to share resources")]
    public partial class SharedResourcesPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Shared Resources";
        public static string StatPInfo { get; set; } = "Using resource dictionaries to share resources";

        [System.ComponentModel.Description("Shared Resources")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Using resource dictionaries to share resources")]
        public string PInfo { get; set; }

        public SharedResourcesPage()
        {
            InitializeComponent();
        }
    }
}