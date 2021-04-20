using System;

using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;

namespace WorkingWithListviewNative
{
	/// <summary>
	/// Xamarin.Forms representation for a custom-renderer that uses 
	/// the native list control on each platform.
	/// </summary>
	public class NativeListView2 : ListView
	{
		public static readonly BindableProperty ItemsProperty = 
			BindableProperty.Create ("Items", typeof(IEnumerable<DataSource2>), typeof(NativeListView2), new List<DataSource2>());

		public IEnumerable<DataSource2> Items {
			get { return (IEnumerable<DataSource2>)GetValue (ItemsProperty); }
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


