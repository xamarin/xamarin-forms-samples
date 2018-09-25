using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PlatformSpecifics
{
    public class AndroidEntryPageCS : ContentPage
	{
        Xamarin.Forms.Entry _entry;
        Label _label;
        Picker _picker;

        public AndroidEntryPageCS()
        {
			var items = new List<string>();
            items.Add(ImeFlags.Default.ToString());
            items.Add(ImeFlags.None.ToString());
            items.Add(ImeFlags.Go.ToString());
            items.Add(ImeFlags.Search.ToString());
            items.Add(ImeFlags.Send.ToString());
            items.Add(ImeFlags.Next.ToString());
            items.Add(ImeFlags.Done.ToString());
            items.Add(ImeFlags.Previous.ToString());
            items.Add(ImeFlags.NoPersonalizedLearning.ToString());
            items.Add(ImeFlags.NoFullscreen.ToString());
            items.Add(ImeFlags.NoExtractUi.ToString());
            items.Add(ImeFlags.NoAccessoryAction.ToString());

			_entry = new Xamarin.Forms.Entry { Placeholder = "User the Picker to set ImeOptions", FontSize = 22 };
			_label = new Label { Text = "ImeOptions: ", FontSize = 20 };
			_picker = new Picker { Title = "Select ImeOptions" };
			_picker.ItemsSource = items;
			_picker.SelectedIndexChanged += OnSelectedIndexChanged;

			Title = "Entry ImeOptions";
            Content = new StackLayout
            {
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = { _entry, _label, _picker }
            };
        }

		void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ImeFlags flag = (ImeFlags)Enum.Parse(typeof(ImeFlags), _picker.SelectedItem.ToString());
            _entry.On<Android>().SetImeOptions(flag);
            _label.Text = $"ImeOptions: {_entry.On<Android>().ImeOptions()}";
        }
    }
}
