using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkupExtensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaticDemoPage : ContentPage
    {
        public StaticDemoPage()
        {
            InitializeComponent();
        }
    }
}