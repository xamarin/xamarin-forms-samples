using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBindingDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicCodeBindingPage : ContentPage
    {
        public BasicCodeBindingPage()
        {
            InitializeComponent();

            label.BindingContext = slider;
            label.SetBinding(Label.RotationProperty, "Value");
        }
    }
}