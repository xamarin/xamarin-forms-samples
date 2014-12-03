using System;

using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;

namespace WorkingWithListViewPerf
{
	/// <summary>
	/// Xamarin.Forms representation for a custom-renderer that uses 
	/// the native list control on each platform.
	/// </summary>
	public class FasterLayoutListView : View
	{
		public static readonly BindableProperty ItemsProperty = 
			BindableProperty.Create ("Items", typeof(IEnumerable<DataSource>), typeof(FasterListView), new List<DataSource>());

		public IEnumerable<DataSource> Items {
			get { return (IEnumerable<DataSource>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); } 
		}

		public FasterLayoutListView ()
		{
		}
	}
}


