using Xamarin.Forms;

namespace Styles
{
	public class NoStylesPageCS : ContentPage
	{
		public NoStylesPageCS ()
		{
			Title = "No Styles";
			Icon = "csharp.png";
			Padding = new Thickness (0, 20, 0, 0);

			Content = new StackLayout { 
				Children = {
					new Label {
						Text = "These labels",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
					},
					new Label {
						Text = "are not",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
					},
					new Label {
						Text = "using styles",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
					} 
				}
			};
		}
	}
}


