using System;

using Xamarin.Forms;

namespace WorkingWithNavigation
{
	public class Page3a : ContentPage
	{
		public Page3a ()
		{
			Title = "Page 3a";
			Content = new StackLayout { 
				BackgroundColor = Color.Blue,
				Children = {
					new Label { Text = "Page 3a", FontSize=Device.GetNamedSize(NamedSize.Large, typeof(Label)) }
				}
			};
		}
	}
}


