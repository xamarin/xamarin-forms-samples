using Xamarin.Forms;

namespace Styles
{
	public class StyleInheritancePageCS : ContentPage
	{
		public StyleInheritancePageCS ()
		{
			var baseStyle = new Style (typeof(View)) {
				Setters = {
					new Setter { 
						Property = View.HorizontalOptionsProperty,
						Value = LayoutOptions.Center
					},
					new Setter {
						Property = View.VerticalOptionsProperty,
						Value = LayoutOptions.CenterAndExpand
					},
				}
			};

			var labelStyle = new Style (typeof(Label)) {
				BasedOn = baseStyle,
				Setters = {
					new Setter {
						Property = Label.FontSizeProperty,
						Value = Device.GetNamedSize (NamedSize.Large, typeof(Label))
					},
					new Setter {
						Property = Label.FontAttributesProperty,
						Value = FontAttributes.Italic
					},
					new Setter {
						Property = Label.TextColorProperty,
						Value = Color.Teal
					} 
				}	
			};

			var buttonStyle = new Style (typeof(Button)) {
				BasedOn = baseStyle,
				Setters = {
					new Setter {
						Property = Button.BorderColorProperty,
						Value =	Color.Lime
					},
					new Setter {
						Property = Button.BorderRadiusProperty,
						Value =	5
					},
					new Setter {
						Property = Button.BorderWidthProperty,
						Value = 5	
					},
					new Setter {
						Property = VisualElement.WidthRequestProperty,
						Value =	200
					},
					new Setter {
						Property = Button.TextColorProperty,
						Value = Color.Teal
					} 
				}	
			};

			Title = "Inheritance";
			Icon = "csharp.png";
			Padding = new Thickness (0, 20, 0, 0);
			Content = new StackLayout { 
				Children = {
					new Label { Text = "These labels", Style = labelStyle },
					new Label { Text = "are demonstrating", Style = labelStyle },
					new Label { Text = "style inheritance", Style = labelStyle },
					new Button { Text = "So is the button", Style = buttonStyle } 
				}
			};
		}
	}
}
