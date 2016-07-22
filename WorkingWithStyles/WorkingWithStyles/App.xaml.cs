using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorkingWithStyles
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();

			// The Application ResourceDictionary is available in Xamarin.Forms 1.3 and later
			if (Application.Current.Resources == null) {
				Application.Current.Resources = new ResourceDictionary();
			}

			var appStyle = new Style (typeof(Label)) {
				BaseResourceKey = Device.Styles.SubtitleStyleKey,
				Setters = {
					new Setter { Property = Label.TextColorProperty, Value = Color.Green }
				}
			};
			Application.Current.Resources.Add ("AppStyle", appStyle);

			var boxStyle = new Style (typeof(BoxView)) {
				Setters = {
					new Setter { Property = BoxView.ColorProperty, Value = Color.Aqua }
				}
			};
			Application.Current.Resources.Add (boxStyle); // implicit style for ALL boxviews

			var tabs = new TabbedPage ();
			tabs.Children.Add (new StylePage {Title = "C#", Icon = "csharp.png"});
			tabs.Children.Add (new StyleXaml {Title = "Xaml", Icon = "xaml.png"});
			tabs.Children.Add (new DynamicResourceXaml {Title = "Dynamic", Icon = "xaml.png"});

			//tabs.Children.Add (new OldResourceDictionary {Title = "Old", Icon = "xaml.png"});

			MainPage = tabs;
		}
	}
}

