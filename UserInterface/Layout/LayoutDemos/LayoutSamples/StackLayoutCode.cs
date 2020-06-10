using System;

using Xamarin.Forms;

namespace LayoutSamples
{
	public class StackLayoutCode : ContentPage
	{
		public StackLayoutCode ()
		{
			var layout = new StackLayout ();
			var box = new BoxView {Color = Color.Red, VerticalOptions = LayoutOptions.FillAndExpand};
			box.VerticalOptions = LayoutOptions.Fill;
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


