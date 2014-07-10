using System;
using Xamarin.Forms;

/*
Glyphish icons from
	http://www.glyphish.com/
under 
	http://creativecommons.org/licenses/by/3.0/us/
support them by buying the full set / Retina versions
*/

namespace WorkingWithMaps
{
	public class App
	{
		public static Page GetMainPage ()
		{	

			var tabs = new TabbedPage ();

			// demonstrates the map control with zooming and map-types
			tabs.Children.Add (new MapPage {Title = "Map/Zoom", Icon = "glyphish_103_map.png"});

			// demonstrates the map control with zooming and map-types
			tabs.Children.Add (new PinPage {Title = "Pins", Icon = "glyphish_07_map_marker.png"});

			// demonstrates the Geocoder class
			tabs.Children.Add (new GeocoderPage {Title = "Geocode", Icon = "glyphish_13_target.png"});

			return tabs;
		}
	}
}

