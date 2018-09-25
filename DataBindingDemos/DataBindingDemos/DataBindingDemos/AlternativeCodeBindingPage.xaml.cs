using Xamarin.Forms;

namespace DataBindingDemos
{
    public partial class AlternativeCodeBindingPage : ContentPage
    {
        public AlternativeCodeBindingPage()
        {
            InitializeComponent();

            label.SetBinding(Label.ScaleProperty, new Binding("Value", source: slider));
        }
    }
}