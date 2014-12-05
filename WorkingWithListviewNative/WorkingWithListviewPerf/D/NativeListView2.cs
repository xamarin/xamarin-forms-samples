using System;

using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;

namespace WorkingWithListviewPerf
{
	/// <summary>
	/// Xamarin.Forms representation for a custom-renderer that uses 
	/// the native list control on each platform.
	/// </summary>
	public class NativeListView2 : View
	{
		public static readonly BindableProperty ItemsProperty = 
			BindableProperty.Create ("Items", typeof(IEnumerable<DataSource>), typeof(NativeListView), new List<DataSource>());

		public IEnumerable<DataSource> Items {
			get { return (IEnumerable<DataSource>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); } 
		}

		public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

		public void NotifyItemSelected (object item) {

			if (ItemSelected != null)
				ItemSelected (this, new SelectedItemChangedEventArgs (item));
		}

		public NativeListView2 ()
		{
		}
	}
}


