using System;

using Xamarin.Forms;

namespace InsightsXamarinFormsTest
{
	public class App : Application
	{


		const string IOS_FONT_NAME_NORMAL = "AvenirNext-Regular";
		const string ANDROID_FONT_NAME_NORMAL = "Roboto";
		const string WINDOWS_FONT_NAME_NORMAL = "Arial";

		const string IOS_FONT_NAME_BOLD = "AvenirNext-DemiBold";
		const string ANDROID_FONT_NAME_BOLD = "Roboto";
		const string WINDOWS_FONT_NAME_BOLD = "Arial";

		public App ()
		{
			var testPage = new TrackView();
			testPage.BindingContext = new TrackViewModel();

			ApplyTheme();

			// The root page of your application
			MainPage = testPage;
		}

		private void ApplyTheme()
		{
			Application.Current.Resources = new ResourceDictionary ();

			// Global styles for all controls of these types
	        var labelStyle = new Style (typeof(Label)) {
	            Setters = {
					new Setter { Property = Label.TextColorProperty, Value = Device.OnPlatform<Color>(Color.FromHex("484848"), Color.FromHex("ECECEC"), Color.FromHex("ECECEC")) },
					new Setter { Property = Label.FontSizeProperty, Value = 12 },
					new Setter { Property = Label.FontFamilyProperty, Value = Device.OnPlatform<string>(IOS_FONT_NAME_NORMAL, ANDROID_FONT_NAME_NORMAL, WINDOWS_FONT_NAME_NORMAL) },
	            }
	        };
			Application.Current.Resources.Add (labelStyle);

			var buttonStyle = new Style (typeof(Button)) {
	            Setters = {
					new Setter { Property = Button.TextColorProperty, Value = Color.FromHex("161616") },
					new Setter { Property = Button.FontFamilyProperty, Value = Device.OnPlatform<string>(IOS_FONT_NAME_BOLD, ANDROID_FONT_NAME_BOLD, WINDOWS_FONT_NAME_BOLD) },
	            }
	        };
			Application.Current.Resources.Add (buttonStyle);

			var pageStyle = new Style (typeof(ContentPage)) {
	            Setters = {
					new Setter { Property = ContentPage.PaddingProperty, Value = Device.OnPlatform<Thickness>(new Thickness(0, 20, 0, 0), 0, 0) },
	            }
	        };
			Application.Current.Resources.Add (pageStyle);
		}
	}
}

