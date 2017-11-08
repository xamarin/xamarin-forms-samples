using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
	public class UnevenRowsCell : ViewCell
	{
		public UnevenRowsCell ()
		{
			var label1 = new Label {
				Text = "Label 1",
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label))
			};
			label1.SetBinding(Label.TextProperty, new Binding("."));

			View = new StackLayout {
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (15, 5, 5, 5),
				Children = { label1 }
			};
		}


//		const int avgCharsInRow = 35;
//		const int defaultHeight = 44;
//		const int extraLineHeight = 20;
//		protected override void OnBindingContextChanged ()
//		{
//			base.OnBindingContextChanged ();
//
//			if (Device.RuntimePlatform == Device.iOS) {
//				var text = (string)BindingContext;
//
//				var len = text.Length;
//
//				if (len < (avgCharsInRow * 2)) {
//					// fits in one cell
//					Height = defaultHeight;
//				} else {
//					len = len - (avgCharsInRow * 2);
//					var extraRows = len / 35;
//					Height = defaultHeight + extraRows * extraLineHeight;
//				}
//			}
//		}
	}
}
