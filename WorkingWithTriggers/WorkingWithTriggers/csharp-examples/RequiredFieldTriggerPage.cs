using System;

using Xamarin.Forms;

namespace WorkingWithTriggers
{
	public class RequiredFieldTriggerPage : ContentPage
	{
		public RequiredFieldTriggerPage ()
		{
			var l = new Label {
				Text = "Entry requires length>0 before button is enabled",
			};
			l.FontSize = Device.GetNamedSize (NamedSize.Small, l); 

			var e = new Entry { Placeholder = "enter name" };

			var b = new Button { Text = "Save",

				HorizontalOptions = LayoutOptions.Center
			};
			b.FontSize = Device.GetNamedSize (NamedSize.Large ,b);

			var dt = new DataTrigger (typeof(Button));
			dt.Binding = new Binding ("Text.Length", BindingMode.Default, source: e);
			dt.Value = 0;
			dt.Setters.Add (new Setter { Property = Button.IsEnabledProperty, Value = false });
			b.Triggers.Add (dt);

			Content = new StackLayout { 
				Padding = new Thickness(0,20,0,0),
				Children = {
					l,
					e,
					b
				}
			};
		}
	}
}