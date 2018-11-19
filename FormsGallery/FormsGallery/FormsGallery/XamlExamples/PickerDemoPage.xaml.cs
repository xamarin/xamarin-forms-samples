using System;
using System.Reflection;
using Xamarin.Forms;

namespace FormsGallery.XamlExamples
{
    public partial class PickerDemoPage : ContentPage
    {
        public PickerDemoPage()
        {
            InitializeComponent();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                boxView.Color = Color.Default;
            }
            else
            {
                string colorName = picker.Items[picker.SelectedIndex];
                FieldInfo colorField = typeof(Color).GetRuntimeField(colorName);
                boxView.Color = (Color)(colorField.GetValue(null));
            }
        }
    }
}