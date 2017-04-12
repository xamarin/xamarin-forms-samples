using System;
using Xamarin.Forms;

namespace PickerDemo
{
	public partial class PickerItemsPage : ContentPage
	{
		public PickerItemsPage()
		{
			InitializeComponent();
		}

		void OnPickerSelectedIndexChanged(object sender, EventArgs e)
		{
			var picker = (Picker)sender;
			int selectedIndex = picker.SelectedIndex;

			if (selectedIndex != -1)
			{
				monkeyNameLabel.Text = picker.Items[selectedIndex];
			}
		}
	}
}
