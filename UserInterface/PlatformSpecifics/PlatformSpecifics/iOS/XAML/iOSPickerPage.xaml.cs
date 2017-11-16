using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PlatformSpecifics
{
    public partial class iOSPickerPage : ContentPage
    {
        public iOSPickerPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            switch (picker.On<iOS>().UpdateMode())
            {
                case UpdateMode.Immediately:
                    picker.On<iOS>().SetUpdateMode(UpdateMode.WhenFinished);
                    break;
                case UpdateMode.WhenFinished:
                    picker.On<iOS>().SetUpdateMode(UpdateMode.Immediately);
                    break;
            }
        }
    }
}
