using System.Collections.Generic;
using Android.Content;
using Android.Widget;

namespace SubclassedNativeControls.Droid
{
	class MySpinner : Spinner
	{
		ArrayAdapter adapter;
		IList<string> items;

		public IList<string> ItemsSource
		{
			get { return items; }
			set
			{
				if (items != value)
				{
					items = value;
					adapter.Clear();

					foreach (string str in items)
					{
						adapter.Add(str);
					}
				}
			}
		}

		public string SelectedObject
		{
			get { return (string)GetItemAtPosition(SelectedItemPosition); }
			set
			{
				if (items != null)
				{
					int index = items.IndexOf(value);
					if (index != -1)
					{
						SetSelection(index);
					}
				}
			}
		}

		public MySpinner(Context context) : base(context)
		{
			ItemSelected += OnBindableSpinnerItemSelected;

			adapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleSpinnerItem);
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			Adapter = adapter;
		}

		void OnBindableSpinnerItemSelected(object sender, ItemSelectedEventArgs args)
		{
			SelectedObject = (string)GetItemAtPosition(args.Position);
		}
	}
}
