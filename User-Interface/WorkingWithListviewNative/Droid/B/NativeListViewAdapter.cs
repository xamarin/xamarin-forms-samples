using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using System.Collections;
using System.Linq;

namespace WorkingWithListviewNative.Droid
{
	public class NativeListViewAdapter: BaseAdapter<string> {

		readonly Activity context;
		IList<string> tableItems = new List<string>();

		public IEnumerable<string> Items {
			set { 
				tableItems = value.ToList();
			}
		}

		public NativeListViewAdapter(Activity context, NativeListView view)
		{
			this.context = context;
			tableItems = view.Items.ToList();
		}
	
		public override string this[int position]
		{
			get
			{ 
				return tableItems[position];
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override int Count
		{
			get { return tableItems.Count; }
		}
	
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			// Get our object for this position
			var item = this.tableItems[position];

			var view = convertView;
			if (view == null) { // no view to re-use, create new
				view = context.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem1, null);
			}

			view.FindViewById<TextView> (global::Android.Resource.Id.Text1).Text = item;

			return view;
		}
	}
}

