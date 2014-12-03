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
	public class FasterListView : View
	{
		public static readonly BindableProperty ItemsProperty = 
			BindableProperty.Create ("Items", typeof(IEnumerable<string>), typeof(FasterListView), new List<string>());

		public IEnumerable<string> Items {
			get { return (IEnumerable<string>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); } 
		}

		public FasterListView ()
		{
		}
	}
}


