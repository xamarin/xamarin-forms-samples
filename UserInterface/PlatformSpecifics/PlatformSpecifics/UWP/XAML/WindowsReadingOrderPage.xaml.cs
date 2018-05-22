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
			UpdateLabels();
        }

		void OnToggleButtonClicked(object sender, EventArgs e)
		{
			_entry1.On<Windows>().SetDetectReadingOrderFromContent(!_entry1.On<Windows>().GetDetectReadingOrderFromContent());
			_entry2.On<Windows>().SetDetectReadingOrderFromContent(!_entry2.On<Windows>().GetDetectReadingOrderFromContent());
			_editor1.On<Windows>().SetDetectReadingOrderFromContent(!_editor1.On<Windows>().GetDetectReadingOrderFromContent());
            _editor2.On<Windows>().SetDetectReadingOrderFromContent(!_editor2.On<Windows>().GetDetectReadingOrderFromContent());
			_label5.On<Windows>().SetDetectReadingOrderFromContent(!_label5.On<Windows>().GetDetectReadingOrderFromContent());

			UpdateLabels();
		}

        void UpdateLabels()
		{
			_label1.Text = $"FlowDirection: {_entry1.FlowDirection}, DetectReadingOrderFromContent: {_entry1.On<Windows>().GetDetectReadingOrderFromContent()}";
            _label2.Text = $"FlowDirection: {_entry2.FlowDirection}, DetectReadingOrderFromContent: {_entry2.On<Windows>().GetDetectReadingOrderFromContent()}";
            _label3.Text = $"FlowDirection: {_editor1.FlowDirection}, DetectReadingOrderFromContent: {_editor1.On<Windows>().GetDetectReadingOrderFromContent()}";
            _label4.Text = $"FlowDirection: {_editor2.FlowDirection}, DetectReadingOrderFromContent: {_editor2.On<Windows>().GetDetectReadingOrderFromContent()}";
            _label6.Text = $"FlowDirection: {_label5.FlowDirection}, DetectReadingOrderFromContent: {_label5.On<Windows>().GetDetectReadingOrderFromContent()}";
		}
    }
}
