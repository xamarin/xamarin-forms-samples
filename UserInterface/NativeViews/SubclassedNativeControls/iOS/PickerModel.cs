using System;
using System.Collections.Generic;
using UIKit;

namespace SubclassedNativeControls.iOS
{
	class PickerModel : UIPickerViewModel
	{
		int selectedIndex = 0;

		public event EventHandler<EventArgs> ItemChanged;

		public IList<string> Items { get; set; }

		public string SelectedItem
		{
			get
			{
				return Items != null && selectedIndex >= 0 && selectedIndex < Items.Count ? Items[selectedIndex] : null;
			}
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return Items != null ? Items.Count : 0;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return Items != null && Items.Count > row ? Items[(int)row] : null;
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			selectedIndex = (int)row;
			if (ItemChanged != null)
			{
				ItemChanged.Invoke(this, new EventArgs());
			}
		}
	}
}
