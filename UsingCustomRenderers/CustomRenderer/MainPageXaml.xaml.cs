using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomRenderer
{	
	public partial class MainPageXaml : ContentPage
	{	
		public MainPageXaml ()
		{
			InitializeComponent ();

			custom.Text = "In Shared Xaml, with code too";
		}
	}
}

