using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public partial class AndroidEntryPage : ContentPage
    {
        public AndroidEntryPage()
        {
            InitializeComponent();
        }

		void OnSelectedIndexChanged(object sender, EventArgs e)
		{
			ImeFlags flag = (ImeFlags)Enum.Parse(typeof(ImeFlags), _picker.SelectedItem.ToString());
			_entry.On<Android>().SetImeOptions(flag);
			_label.Text = $"ImeOptions: {_entry.On<Android>().ImeOptions()}";
		}
    }
}
