using Xamarin.Forms;

namespace WorkingWithBehaviors
{
	public class NumericValidationPageCS : ContentPage
	{
		public NumericValidationPageCS ()
		{
			Title = "Numeric";
			Icon = "csharp.png";

			var entry = new Entry { Placeholder = "Enter a System.Double" };
			entry.Behaviors.Add (new NumericValidationBehavior ());

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
