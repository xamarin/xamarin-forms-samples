using System;

using Xamarin.Forms;

namespace WorkingWithTriggers
{
	public class SimpleTriggerPage : ContentPage
	{
		public SimpleTriggerPage ()
		{
			var t = new Trigger (typeof(Entry));
			t.Property = Entry.IsFocusedProperty;
			t.Value = true;
			t.Setters.Add (new Setter {Property = Entry.ScaleProperty, Value = 1.5 } );


			var s = new Style (typeof(Entry));
			s.Setters.Add (new Setter { Property = AnchorXProperty, Value = 0} );
			s.Triggers.Add (t);

			Resources = new ResourceDictionary ();
			Resources.Add (s);


			Padding = new Thickness (20, 50, 120, 0);
			Content = new StackLayout { 
				Spacing = 20,
				Children = {
					new Entry { Placeholder = "enter name" },
					new Entry { Placeholder = "enter address" },
					new Entry { Placeholder = "enter city and name" },
				}
			};
		}
	}
}


