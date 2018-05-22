using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace PlatformSpecifics
{
    public class WindowsReadingOrderPageCS : ContentPage
    {
		Entry _entry1, _entry2;
		Editor _editor1, _editor2;
		Xamarin.Forms.Label _label1, _label2, _label3, _label4, _label5, _label6;

        public WindowsReadingOrderPageCS()
        {
			_entry1 = new Entry { Text = "היסט?שכל !ורי !ה שכל ב", FlowDirection = FlowDirection.LeftToRight };
			_entry2 = new Entry { Text = "Hello Xamarin Forms! Hello World", FlowDirection = FlowDirection.RightToLeft };
			_editor1 = new Editor { Text = " שכל, ניווט ומהימנה תאולוגיה היא ב, זכר או מדעי תרומה מבוקשים. של ויש טכנולוגיה סוציולוגיה, מה אנא ביולי בקלות למחיקה. על חשמל אקטואליה רבה, שדרות ערכים ננקטת שמו בה. או עוד ציור מיזמים טבלאות, ריקוד קולנוע היסטוריה שכל ב", FlowDirection = FlowDirection.LeftToRight };
			_editor2 = new Editor { Text = "Lorem ipsum dolor sit amet, qui eleifend adversarium ei, pro tamquam pertinax inimicus ut. Quis assentior ius no, ne vel modo tantas omnium, sint labitur id nec. Mel ad cetero repudiare definiebas, eos sint placerat cu", FlowDirection = FlowDirection.LeftToRight};

			_label1 = new Xamarin.Forms.Label();
			_label2 = new Xamarin.Forms.Label();
			_label3 = new Xamarin.Forms.Label();
			_label4 = new Xamarin.Forms.Label();
			_label5 = new Xamarin.Forms.Label { Text = "היסט?שכל !ורי !ה שכל ב", FlowDirection = FlowDirection.LeftToRight };
			_label6 = new Xamarin.Forms.Label();

			var toggleButton = new Button { Text = "Toggle detect from content" };
			toggleButton.Clicked += OnToggleButtonClicked;

			Title = "Text Reading Order";
            Content = new ScrollView
            {
				Margin = new Thickness(20),
                Content = new StackLayout 
				{
					Children = { _entry1, _label1, _entry2, _label2, _editor1, _label3, _editor2, _label4, _label5, _label6, toggleButton }
                }
            };
			OnToggleButtonClicked(this, null);
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