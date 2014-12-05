using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using System.Collections;
using System.Linq;

namespace WorkingWithListviewPerf.Droid
{
	public class FasterListViewAdapter: BaseAdapter<string> {

		readonly Activity context;
		IList<string> tableItems = new List<string>();

		public IEnumerable<string> Items {
			set { 
				tableItems = value.ToList();
			}
		}

		public FasterListViewAdapter(Activity context, NativeListView view)
		{
			this.context = context;
			tableItems = view.Items.ToList();
		}
	
		public override string this[int position]
		{
			get
			{ // this'll break if called with a 'header' position
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

		/// <summary>
		/// Grouped list: view could be a 'section heading' or a 'data row'
		/// </summary>
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			// Get our object for this position
			var item = this.tableItems[position];

			var view = context.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem1, null);

			view.FindViewById<TextView> (global::Android.Resource.Id.Text1).Text = item;

			return view;
		}
	}
}

