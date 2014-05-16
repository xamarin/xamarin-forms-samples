using System;
using Xamarin.Forms;

namespace FormsControls
{
	public class Labels : ContentPage
	{
		public Labels ()
		{
			Content = new StackLayout {
				Spacing = 40,
				Children = {
					new Label () {
						Text = "This is just a normal label."
					},

					new Label () {
						Text = "This label has very small text.",
						Font = Font.SystemFontOfSize (NamedSize.Micro)
					},

					new Label () {
						Text = "This label will be truncated! In fact, the sheer amount of text could never fit in one line on the majority of devices!" +
							" We should probably set a proper line break mode so that we can properly display all of this data to you.",
						LineBreakMode = LineBreakMode.NoWrap,
						Font = Font.BoldSystemFontOfSize (NamedSize.Large)
					},

					new Label () {
						Text = "This label contains a whole bunch of text. In fact, the sheer amount of text could never fit in one line on the majority of devices!" +
							" We should probably set a proper line break mode so that we can properly display all of this data to you.",
						LineBreakMode = LineBreakMode.WordWrap
					},
						
					new Label () {
						Text = "This label has been customized. Far out!",
						Font = Font.BoldSystemFontOfSize (24),
						BackgroundColor = Color.Purple,
						TextColor = Color.Lime,
						IsVisible = true,
					},
				}	
			};
		}
	}
}

