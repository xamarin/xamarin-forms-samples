using System;
using Xamarin.Forms;

namespace FormsControls
{
	public class Images : ContentPage
	{
		public Images ()
		{


			Content = new StackLayout {
				Spacing = 40,
				Children = {
					new Image (){
						Source = ImageSource.FromResource ("icon.png")
					}

				}	
			};
		}
	}
}

