using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBindingDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleSettingsPage : ContentPage
    {
        public SampleSettingsPage()
        {
            InitializeComponent();

            if (colorListView.SelectedItem != null)
            {
                colorListView.ScrollTo(colorListView.SelectedItem, 
                                       ScrollToPosition.MakeVisible, 
                                       false);
            }
        }
    }
}