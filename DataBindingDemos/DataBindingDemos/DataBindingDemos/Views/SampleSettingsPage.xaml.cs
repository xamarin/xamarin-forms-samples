using Xamarin.Forms;

namespace DataBindingDemos
{
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