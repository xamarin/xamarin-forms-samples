using System;
using Xamarin.Forms;

namespace Styles
{
	public class DynamicStylesPageCS : ContentPage
	{
		bool originalStyle = true;

		public DynamicStylesPageCS ()
		{
			Title = "Dynamic";
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
						Property = SearchBar.PlaceholderColorProperty,
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
						Property = SearchBar.PlaceholderColorProperty,
						Value = Color.Green
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

			var searchBar1 = new SearchBar { Placeholder = "These SearchBar controls" };
			searchBar1.SetDynamicResource (VisualElement.StyleProperty, "searchBarStyle");
			var searchBar2 = new SearchBar { Placeholder = "are demonstrating" };
			searchBar2.SetDynamicResource (VisualElement.StyleProperty, "searchBarStyle");
			var searchBar3 = new SearchBar { Placeholder = "dynamic styles, " };
			searchBar3.SetDynamicResource (VisualElement.StyleProperty, "searchBarStyle");
			var searchBar4 = new SearchBar { Placeholder = "but this isn't dynamic", Style = blueSearchBarStyle };

			var button = new Button { Text = "Change Style", Style = buttonStyle };
			button.Clicked += OnButtonClicked;

			Resources = new ResourceDictionary ();
			Resources.Add ("blueSearchBarStyle", blueSearchBarStyle);
			Resources.Add ("greenSearchBarStyle", greenSearchBarStyle);
			Resources ["searchBarStyle"] = Resources ["blueSearchBarStyle"];

			Content = new StackLayout { 
				Children = {
					searchBar1,
					searchBar2,
					searchBar3,
					searchBar4,
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
