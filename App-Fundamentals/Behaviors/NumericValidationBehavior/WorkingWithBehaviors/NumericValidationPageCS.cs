using Xamarin.Forms;

namespace WorkingWithBehaviors
{
	public class NumericValidationPageCS : ContentPage
	{
		public NumericValidationPageCS ()
		{
			Title = "Numeric";
			IconImageSource = "csharp.png";

			var entry = new Entry { Placeholder = "Enter a System.Double" };
			entry.Behaviors.Add (new NumericValidationBehavior ());

			Content = new StackLayout {
				Padding = new Thickness (5, 50, 5, 0),
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
