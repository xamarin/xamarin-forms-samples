using System;
using Xamarin.Forms;

namespace WorkingWithColors
{
	public class ColorDemo : ContentPage
	{
		public ColorDemo ()
		{
			var red    = new Label { Text = "Red",   BackgroundColor = Color.Red };
			var orange = new Label { Text = "Orange",BackgroundColor = Color.FromHex("FF6A00") };
			var yellow = new Label { Text = "Yellow",BackgroundColor = Color.FromHsla(0.167, 1.0, 0.5, 1.0) };
			var green  = new Label { Text = "Green", BackgroundColor = Color.FromRgb (38, 127, 0) };
			var blue   = new Label { Text = "Blue",  BackgroundColor = Color.FromRgba(0, 38, 255, 255) };
			var indigo = new Label { Text = "Indigo",BackgroundColor = Color.FromRgb (0, 72, 255) };
			var violet = new Label { Text = "Violet",BackgroundColor = Color.FromHsla(0.82, 1, 0.25, 1) };

			var space = new Label       { Text = " ",          BackgroundColor = Color.Transparent };

			var transparent = new Label { Text = "Transparent",BackgroundColor = Color.Transparent };
			var @default = new Label    { Text = "Default",    BackgroundColor = Color.Default };
			var accent = new Label      { Text = "Accent",     BackgroundColor = Color.Accent };


			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Color Demo",
						FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
						FontAttributes = FontAttributes.Bold
					},
					red, orange, yellow, green, blue, indigo, violet,
					space,
					transparent, @default, accent
				}
			};
		}
	}
}

