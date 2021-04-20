using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSTimePickerPage : ContentPage
    {
        public iOSTimePickerPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            switch (timePicker.On<iOS>().UpdateMode())
            {
                case UpdateMode.Immediately:
                    timePicker.On<iOS>().SetUpdateMode(UpdateMode.WhenFinished);
                    break;
                case UpdateMode.WhenFinished:
                    timePicker.On<iOS>().SetUpdateMode(UpdateMode.Immediately);
                    break;
            }
        }
    }
}
