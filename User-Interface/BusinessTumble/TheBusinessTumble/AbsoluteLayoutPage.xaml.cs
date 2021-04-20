using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheBusinessTumble
{
	public partial class AbsoluteLayoutPage : ContentPage
	{
		public AbsoluteLayoutPage ()
		{
			InitializeComponent ();
		}

		public override string ToString(){
			return this.Title;
		}
	}
}

