using Xamarin.Forms;

namespace AttachedNumericValidationBehavior
{
	public class NumericValidationPageCS : ContentPage
	{
		public NumericValidationPageCS ()
		{
			Title = "Numeric";
			IconImageSource = "csharp.png";

			var entry = new Entry { Placeholder = "Enter a System.Double" };
			NumericValidationBehavior.SetAttachBehavior (entry, true);

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Red when the number isn't valid",
						FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label))
					},
					entry
				}
			};
		}
	}
}
