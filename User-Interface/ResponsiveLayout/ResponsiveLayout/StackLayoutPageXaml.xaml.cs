using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ResponsiveLayout
{
	public partial class StackLayoutPageXaml : ContentPage
	{
		private double width;
		private double height;
		public StackLayoutPageXaml ()
		{
			InitializeComponent ();
		}

		protected override void OnSizeAllocated (double width, double height){
			base.OnSizeAllocated (width, height);
			if (width != this.width || height != this.height) {
				this.width = width;
				this.height = height;
				if (width > height) {
					outerStack.Orientation = StackOrientation.Horizontal;
				} else {
					outerStack.Orientation = StackOrientation.Vertical;
				}
			}
		}
	}
}

