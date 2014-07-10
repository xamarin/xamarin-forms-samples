using System;
using Xamarin.Forms;

namespace WorkingWithMaps
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			// demonstrates the map control with zooming and map-types
			return new MapPage ();

			// demonstrates the Geocoder class
//			return new GeocoderPage ();
		}
	}
}

