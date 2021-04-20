using System;
using MediaElementDemos.Controls;
using Xamarin.Forms;

namespace MediaElementDemos
{
    public partial class AspectVideoPage : ContentPage
    {
        public AspectVideoPage()
        {
            InitializeComponent();
        }

        void OnAspectSelectedIndexChanged(object sender, EventArgs e)
        {
            mediaElement.Aspect = (Aspect)(sender as EnumPicker).SelectedItem;
        }
    }
}
