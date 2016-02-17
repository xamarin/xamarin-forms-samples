using Xamarin.Forms;

namespace Styles
{
	public class ExplicitStylesPageCS : ContentPage
	{
		public ExplicitStylesPageCS ()
		{
			var labelRedStyle = new Style (typeof(Label)) {
				Setters = {
					new Setter { 
						Property = View.HorizontalOptionsProperty,
						Value = LayoutOptions.Center
					},
					new Setter {
						Property = View.VerticalOptionsProperty,
						Value = LayoutOptions.CenterAndExpand
					},
					new Setter {
						Property = Label.FontSizeProperty,
						Value = Device.GetNamedSize (NamedSize.Large, typeof(Label))
					},
					new Setter {
						Property = Label.TextColorProperty,
						Value = Color.Red
					}
				}	
			};

			var labelGreenStyle = new Style (typeof(Label)) {
				Setters = {
					new Setter { 
						Property = View.HorizontalOptionsProperty,
						Value = LayoutOptions.Center
					},
					new Setter {
						Property = View.VerticalOptionsProperty,
						Value = LayoutOptions.CenterAndExpand
					},
					new Setter {
						Property = Label.FontSizeProperty,
						Value = Device.GetNamedSize (NamedSize.Large, typeof(Label))
					},
					new Setter {
						Property = Label.TextColorProperty,
						Value = Color.Green
					}
				}	
			};

			var labelBlueStyle = new Style (typeof(Label)) {
				Setters = {
					new Setter { 
						Property = View.HorizontalOptionsProperty,
						Value = LayoutOptions.Center
					},
					new Setter {
						Property = View.VerticalOptionsProperty,
						Value = LayoutOptions.CenterAndExpand
					},
					new Setter {
						Property = Label.FontSizeProperty,
						Value = Device.GetNamedSize (NamedSize.Large, typeof(Label))
					},
					new Setter {
						Property = Label.TextColorProperty,
						Value = Color.Blue
					}
				}	
			};

			Title = "Explicit";
			Icon = "csharp.png";
			Padding = new Thickness (0, 20, 0, 0);
			Content = new StackLayout { 
				Children = {
					new Label { Text = "These labels", Style = labelRedStyle },
					new Label { Text = "are demonstrating", Style = labelGreenStyle },
					new Label { Text = "explicit styles,", Style = labelBlueStyle },
					new Label { Text = "and an explicit style override", Style = labelBlueStyle, TextColor = Color.Teal } 
				}
			};
		}
	}
}

