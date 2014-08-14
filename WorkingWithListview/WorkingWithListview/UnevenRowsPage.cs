using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
	public class UnevenRowsPage : ContentPage
	{
		public UnevenRowsPage ()
		{
			var listView = new ListView ();

			listView.HasUnevenRows = true;

			// http://en.wikipedia.org/wiki/To_be,_or_not_to_be
			listView.ItemsSource = new [] { 
				"To be, or not to be,", 
				"that is the question— Whether 'tis Nobler in the mind to suffer",
				@"The Slings and Arrows of outrageous Fortune,
Or to take Arms against a Sea of troubles,",
				@"And by opposing end them? To die, to sleep—
No more; and by a sleep, to say we end
The Heart-ache, and the thousand Natural shocks",
				@"That Flesh is heir to? 'Tis a consummation
Devoutly to be wished. To die, to sleep,
To sleep, perchance to Dream; Aye, there's the rub,
For in that sleep of death, what dreams may come,",
				@"When we have shuffled off this mortal coil,
Must give us pause. "
			
			};
			listView.ItemTemplate = new DataTemplate(typeof(UnevenRowsCell));

			listView.ItemTapped += (sender, e) => {
				if (e == null) return; // has been set to null, do not 'process' tapped event
				Debug.WriteLine("Tapped: " + e.Item);
				((ListView)sender).SelectedItem = null; // de-select the row
			};

			Padding = new Thickness (0,20,0,0);
			Content = listView;
		}
	}
}

