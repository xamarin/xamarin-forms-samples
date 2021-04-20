using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheBusinessTumble
{
	public partial class RelativeLayoutPage : ContentPage
	{
		public RelativeLayoutPage ()
		{
			InitializeComponent ();
		}

		public override string ToString(){
			return this.Title;
		}
	}
}

