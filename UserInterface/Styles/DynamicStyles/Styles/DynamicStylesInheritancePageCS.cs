using System;
using Xamarin.Forms;

namespace Styles
{
	public class DynamicStylesInheritancePageCS : ContentPage
	{
		bool originalStyle = true;

		public DynamicStylesInheritancePageCS ()
		{
			Title = "Dynamic Inheritance";
			Icon = "csharp.png";
			Padding = new Thickness (0, 20, 0, 0);

			var baseStyle = new Style (typeof(View)) {
				Setters = {
					new Setter {
						Property = View.VerticalOptionsProperty,
						Value = LayoutOptions.CenterAndExpand
					}
				}
			};

			var blueSearchBarStyle = new Style (typeof(SearchBar)) {
				BasedOn = baseStyle,
				Setters = {
					new Setter {
						Property = SearchBar.FontAttributesProperty,
						Value = FontAttributes.Italic
					},
					new Setter {
						Property = SearchBar.TextColorProperty,
						Value = Color.Blue
					} 
				}	
			};

			var greenSearchBarStyle = new Style (typeof(SearchBar)) {
				Setters = {
					new Setter {
						Property = SearchBar.FontAttributesProperty,
						Value = FontAttributes.None
					},
					new Setter {
						Property = SearchBar.TextColorProperty,
						Value = Color.Green
					}
				}	
			};

			var tealSearchBarStyle = new Style (typeof(SearchBar)) {
				BaseResourceKey = "searchBarStyle",
				Setters = {
					new Setter {
						Property = VisualElement.BackgroundColorProperty,
						Value = Color.Teal
					},
					new Setter { 
						Property = SearchBar.CancelButtonColorProperty,
						Value = Color.White
					}
				}
			};

			var buttonStyle = new Style (typeof(Button)) {
				BasedOn = baseStyle,
				Setters = {
					new Setter {
						Property = Button.FontSizeProperty,
						Value = Device.GetNamedSize (NamedSize.Large, typeof(Button))
					},
					new Setter {
						Property = Button.TextColorProperty,
						Value = Color.Red
					} 
				}	
			};

			var button = new Button { Text = "Change Style", Style = buttonStyle };
			button.Clicked += OnButtonClicked;

			Resources = new ResourceDictionary ();
			Resources.Add ("blueSearchBarStyle", blueSearchBarStyle);
			Resources.Add ("greenSearchBarStyle", greenSearchBarStyle);
			Resources ["searchBarStyle"] = Resources ["blueSearchBarStyle"];

			Content = new StackLayout { 
				Children = {
					new SearchBar { Text = "These SearchBar controls", Style = tealSearchBarStyle },
					new SearchBar { Text = "are demonstrating", Style = tealSearchBarStyle },
					new SearchBar { Text = "dynamic style inheritance, ", Style = tealSearchBarStyle },
					new SearchBar { Text = "but this isn't dynamic", Style = (Style)Resources ["blueSearchBarStyle"] },
					button
				}
			};
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			if (originalStyle) {
				Resources ["searchBarStyle"] = Resources ["greenSearchBarStyle"];
				originalStyle = false;
			} else {
				Resources ["searchBarStyle"] = Resources ["blueSearchBarStyle"];
				originalStyle = true;
			}
		}
	}
}
