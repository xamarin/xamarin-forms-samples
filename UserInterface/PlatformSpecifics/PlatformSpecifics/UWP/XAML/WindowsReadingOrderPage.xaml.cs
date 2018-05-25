using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public partial class WindowsReadingOrderPage : ContentPage
    {
        public WindowsReadingOrderPage()
        {
            InitializeComponent();
            UpdateLabel();
        }

        void OnToggleButtonClicked(object sender, EventArgs e)
        {
            _editor.On<Windows>().SetDetectReadingOrderFromContent(!_editor.On<Windows>().GetDetectReadingOrderFromContent());
            UpdateLabel();
        }

        void UpdateLabel()
        {
            _label.Text = $"FlowDirection: {_editor.FlowDirection}, DetectReadingOrderFromContent: {_editor.On<Windows>().GetDetectReadingOrderFromContent()}";
        }
    }
}
