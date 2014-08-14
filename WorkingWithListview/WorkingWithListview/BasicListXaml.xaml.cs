using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WorkingWithListview
{	
	public partial class BasicListXaml : ContentPage
	{	
		public BasicListXaml ()
		{
			InitializeComponent ();

			this.BindingContext = new [] { "a", "b", "c" };
		}
	}
}

