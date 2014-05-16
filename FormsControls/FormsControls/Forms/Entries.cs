using System;
using Xamarin.Forms;

namespace FormsControls
{
	public class Entries : ContentPage
	{
		public Entries ()
		{
			var parent = new StackLayout {
				Spacing = 40
			};

			var standard =  new StackLayout {
				Children = {
					new Label () {
						Text = "Standard Entry"
					},

					new Entry () {
					Text = ""
					},
				}
			};


		
			parent.Children.Add (standard);
			Content = parent;
		}
	}
}

