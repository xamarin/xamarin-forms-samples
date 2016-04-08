using Xamarin.Forms;

namespace Styles
{
	public class DeviceStylesPageCS : ContentPage
	{
		public DeviceStylesPageCS ()
		{
			var myBodyStyle = new Style (typeof(Label)) {
				BaseResourceKey = Device.Styles.BodyStyleKey,
				Setters = {
					new Setter {
						Property = Label.TextColorProperty,
						Value = Color.Accent
					} 
				}
			};

			Title = "Device";
			Icon = "csharp.png";
			Padding = new Thickness (0, 20, 0, 0);

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Title style", Style = Device.Styles.TitleStyle },
					new Label { Text = "Subtitle style", Style = Device.Styles.SubtitleStyle },
					new Label { Text = "Body style", Style = Device.Styles.BodyStyle }, 
					new Label { Text = "Caption style", Style = Device.Styles.CaptionStyle },
					new Label { Text = "List item detail text style", Style = Device.Styles.ListItemDetailTextStyle },
					new Label { Text = "List item text style", Style = Device.Styles.ListItemTextStyle },
					new Label { Text = "No style" }, 
					new Label { Text = "My body style", Style = myBodyStyle }
				}
			};
		}
	}
}
