using System;
using System.Collections.Generic;
using UIKit;

namespace SubclassedNativeControls.iOS
{
	public class MyUIPickerView : UIPickerView
	{
		public event EventHandler<EventArgs> SelectedItemChanged;

		public MyUIPickerView()
		{
			var model = new PickerModel();
			model.ItemChanged += (sender, e) =>
			{
				if (SelectedItemChanged != null)
				{
					SelectedItemChanged.Invoke(this, e);
				}
			};
			Model = model;
		}

		public IList<string> ItemsSource
		{
			get
			{
				var pickerModel = Model as PickerModel;
				return (pickerModel != null) ? pickerModel.Items : null;
			}
			set
			{
				var model = Model as PickerModel;
				if (model != null)
				{
					model.Items = value;
				}
			}
		}

		public string SelectedItem
		{
			get { return (Model as PickerModel).SelectedItem; }
			set { }
		}
	}
}
