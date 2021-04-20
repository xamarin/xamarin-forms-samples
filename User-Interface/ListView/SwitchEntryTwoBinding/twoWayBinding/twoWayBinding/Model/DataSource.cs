using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace twoWayBinding
{
	public static class DataSource
	{
		static DataSource ()
		{
		}

		public static void persist(List<light> lights)
		{
			//do something here
		}

		public static ObservableCollection<light> getLights()
		{
			ObservableCollection<light> lights = new ObservableCollection<light> () {
				new light(false, "Bedside", Color.Blue, "Mel's Bedroom"),
				new light(false, "Desk", Color.Red, "Mel's Bedroom"),
				new light(false, "Flood Lamp", Color.Olive, "Outside"),
				new light(false, "hallway1", Color.Teal, "Entry Hallway"),
				new light(false, "hallway2", Color.Purple, "Entry Hallway")
			};
			return lights;
		}
	}
}

