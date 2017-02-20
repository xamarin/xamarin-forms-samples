using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MapOverlay;
using MapOverlay.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

[assembly:ExportRenderer (typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.Droid
{
	public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
	{
		GoogleMap map;
		List<Position> shapeCoordinates;

		protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) {
				// Unsubscribe
			}

			if (e.NewElement != null) {
				var formsMap = (CustomMap)e.NewElement;
				shapeCoordinates = formsMap.ShapeCoordinates;

				((MapView)Control).GetMapAsync (this);
			}
		}

		public void OnMapReady (GoogleMap googleMap)
		{
			map = googleMap;

			var polygonOptions = new PolygonOptions ();
			polygonOptions.InvokeFillColor (0x66FF0000);
			polygonOptions.InvokeStrokeColor (0x660000FF);
			polygonOptions.InvokeStrokeWidth (30.0f);

			foreach (var position in shapeCoordinates) {
				polygonOptions.Add (new LatLng (position.Latitude, position.Longitude));
			}

			map.AddPolygon (polygonOptions);
		}
	}
}
