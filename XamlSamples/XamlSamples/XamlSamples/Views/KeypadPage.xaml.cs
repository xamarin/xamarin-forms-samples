using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlSamples.Views
{
    [System.ComponentModel.Description("Keypad~Use a view model for numeric keypad logic")]
    public partial class KeypadPage : ContentPage
    {
        public static string StatPTitle { get; set; } = "Keypad";
        public static string StatPInfo { get; set; } = "Use a view model for numeric keypad logic";

        [System.ComponentModel.Description("Keypad")]
        public string PTitle { get; set; }

        [System.ComponentModel.Description("Use a view model for numeric keypad logic")]
        public string PInfo { get; set; }

        public KeypadPage()
        {
            InitializeComponent();
        }
    }
}