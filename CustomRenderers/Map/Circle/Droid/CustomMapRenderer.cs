using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MapOverlay;
using MapOverlay.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;

[assembly:ExportRenderer (typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.Droid
{
	public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
	{
		GoogleMap map;
		CustomCircle circle;

		protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) {
				// Unsubscribe
			}

			if (e.NewElement != null) {
				var formsMap = (CustomMap)e.NewElement;
				circle = formsMap.Circle;

				((MapView)Control).GetMapAsync (this);
			}
		}

		public void OnMapReady (GoogleMap googleMap)
		{
			map = googleMap;

			var circleOptions = new CircleOptions ();
			circleOptions.InvokeCenter (new LatLng (circle.Position.Latitude, circle.Position.Longitude));
			circleOptions.InvokeRadius (circle.Radius);
			circleOptions.InvokeFillColor (0X66FF0000);
			circleOptions.InvokeStrokeColor (0X66FF0000);
			circleOptions.InvokeStrokeWidth (0);
			map.AddCircle (circleOptions);
		}
	}
}
