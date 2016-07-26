using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LayoutSamples
{
	public partial class ScrollingDemoXAML : ContentPage
	{
		public ScrollingDemoXAML ()
		{
			InitializeComponent ();
			scroll.ScrollToAsync (target, ScrollToPosition.Center, true);
			scroll.Scrolled+= (object sender, ScrolledEventArgs e) => {
				label.Text = "Position: " + e.ScrollX + " x " + e.ScrollY;
			};
		}

	}
}

