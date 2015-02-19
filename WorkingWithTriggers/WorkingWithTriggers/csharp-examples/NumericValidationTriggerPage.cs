using System;

using Xamarin.Forms;

namespace WorkingWithTriggers
{
	public class NumericValidationTriggerPage : ContentPage
	{
		public NumericValidationTriggerPage ()
		{
			var t = new EventTrigger ();
			t.Event = "TextChanged";
			t.Actions.Add (new NumericValidationTriggerAction ());




			var l = new Label { Text = "Text becomes red if the entry is not a valid double" };
			l.FontSize = Device.GetNamedSize (NamedSize.Small, l);

			var e = new Entry { 
				Placeholder = "Enter a System.Double"
			};
			e.Triggers.Add(t);

			Padding = new Thickness (0, 20, 0, 0);
			Content = new StackLayout { 
				Children = {
					l,
					e
				}
			};
		}
	}
}


