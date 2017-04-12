using CoreLocation;
using MapKit;
using MapOverlay;
using MapOverlay.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer (typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.iOS
{
	public class CustomMapRenderer : MapRenderer
	{
		MKPolygonRenderer polygonRenderer;

		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) {
				var nativeMap = Control as MKMapView;
				nativeMap.OverlayRenderer = null;
			}

			if (e.NewElement != null) {
				var formsMap = (CustomMap)e.NewElement;
				var nativeMap = Control as MKMapView;

				nativeMap.OverlayRenderer = GetOverlayRenderer;

				CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[formsMap.ShapeCoordinates.Count];

				int index = 0;
				foreach (var position in formsMap.ShapeCoordinates) {
					coords [index] = new CLLocationCoordinate2D (position.Latitude, position.Longitude);
					index++;
				}

				var blockOverlay = MKPolygon.FromCoordinates (coords);
				nativeMap.AddOverlay (blockOverlay);
			}
		}

		MKOverlayRenderer GetOverlayRenderer (MKMapView mapView, IMKOverlay overlay)
		{
			if (polygonRenderer == null) {
				polygonRenderer = new MKPolygonRenderer (overlay as MKPolygon);
				polygonRenderer.FillColor = UIColor.Red;
				polygonRenderer.StrokeColor = UIColor.Blue;
				polygonRenderer.Alpha = 0.4f;
				polygonRenderer.LineWidth = 9;
			}
			return polygonRenderer;
		}
	}
}
