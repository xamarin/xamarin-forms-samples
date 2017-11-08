using System;
using Xamarin.Forms;

namespace WorkingWithStyles
{
	public class StylePage : ContentPage
	{
		public StylePage ()
		{
			Content = new StackLayout {
				Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0),
				Children = {
					new Label {
						Text = "This uses TitleStyle",
						Style = Device.Styles.TitleStyle
					},
					new Label {
						Text = "This uses SubtitleStyle",
						Style = Device.Styles.SubtitleStyle
					},
					new Label {
						Text = "This uses BodyStyle",
						Style = Device.Styles.BodyStyle
					},
					new Label {
						Text = "This uses CaptionStyle",
						Style = Device.Styles.CaptionStyle
					},
					new Button {
						Text = "Style Me",
						Style = new Style (typeof(Button)) {
							Setters = {
								new Setter {Property = Button.BackgroundColorProperty, Value = Color.Yellow},
								new Setter {Property = Button.BorderRadiusProperty, Value = 0},
								new Setter {Property = Button.HeightRequestProperty, Value = 42}
							}
						}
					},
					// custom style declared in code
					new Label {
						Text = "This uses a custom style inherited dynamically from SubtitleStyle",
						Style = new Style (typeof(Label)) {
							BaseResourceKey = Device.Styles.SubtitleStyleKey,
							Setters = {
								new Setter {Property = Label.TextColorProperty, Value = Color.Pink}
							}
						}
					},
					// global style defined in the Application subclass
					new Label {
						Text = "This uses a custom style inherited dynamically from the Application ResourceDictionary",
						Style = Application.Current.Resources["AppStyle"] as Style
					},
					// global style defined in the Application subclass
					new Label {
						Text = "This uses an implicit style from the Application ResourceDictionary",
					},
					// uses implicit style that applies to all BoxViews
					new BoxView ()
				}
			};
		}
	}
}
