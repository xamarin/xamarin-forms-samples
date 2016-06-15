using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheBusinessTumble
{
	public partial class StackLayoutPage : ContentPage
	{
		public StackLayoutPage ()
		{
			InitializeComponent ();
		}

		public override string ToString(){
			return this.Title;
		}
	}
}

