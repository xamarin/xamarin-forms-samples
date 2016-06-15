using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkingWithImages
{
	public class LocalImages : ContentPage
	{
		public LocalImages ()
		{
			var beachImage = new Image { WidthRequest = 300, HeightRequest = 300 };
			beachImage.Source = ImageSource.FromFile ("waterfront.jpg");
			beachImage.Aspect = Aspect.AspectFit;

			Content = new StackLayout {
				Children = {
					new Label {
						Text = "ImageSource.FromFile",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					},
					beachImage, 
					new Label { Text = "waterfront.jpg has been added each application project: iOS, Android and Windows Phone. On iOS and Android multiple resolutions are supplied and resolved at runtime." }
				},
				Padding = new Thickness (0, 20, 0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
		}
	}
}
