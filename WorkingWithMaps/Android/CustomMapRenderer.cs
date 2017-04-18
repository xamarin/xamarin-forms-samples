using System.Collections.Generic;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MarineOps.Common.CustomRenderers;
using MarineOps.Common.Resources.Images;
using MarineOps.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MarineOps.Droid.Renderers
{
    public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        private bool _disposed = false;
        private GoogleMap _map;
        private CustomMap _formsMap;


        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _map.MarkerClick -= HandleMarkerClick;
            _formsMap = null;
            _map = null;
            _disposed = true;

            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _formsMap = (CustomMap)e.NewElement;
                ((MapView)Control).GetMapAsync(this);
            }
        }
        

        public void OnMapReady(GoogleMap googleMap)
        {
            if (_map != null) return;

            _map = googleMap;

            _map.Clear();
            _map.MarkerClick += HandleMarkerClick;
            _map.MyLocationEnabled = _formsMap.IsShowingUser;

            foreach (var formsPin in _formsMap.CustomPins)
            {

                var markerWithIcon = new MarkerOptions();
                markerWithIcon.SetPosition(new LatLng(formsPin.Pin.Position.Latitude,
                    formsPin.Pin.Position.Longitude));
                markerWithIcon.SetTitle(formsPin.Pin.Label);
                markerWithIcon.SetSnippet(formsPin.Pin.Address);

                if (formsPin.Angle > 0)
                {
                    markerWithIcon.SetRotation((float) formsPin.Angle);
                }
                markerWithIcon.SetIcon(formsPin.Filename == ImageResources.MapPortIcon
                    ? BitmapDescriptorFactory.FromResource(Resource.Drawable.mapPortWhite)
                    : BitmapDescriptorFactory.FromResource(Resource.Drawable.mapVesselWhite));


                var m = _map.AddMarker(markerWithIcon);

                if (formsPin.RouteCoordinates.Any())
                {
                    var polylineOptions = new PolylineOptions();
                    polylineOptions.InvokeColor(0x66FF0000);

                    foreach (var coordinate in formsPin.RouteCoordinates)
                    {
                        polylineOptions.Add(new LatLng(coordinate.Latitude, coordinate.Longitude));
                    }

                    _map.AddPolyline(polylineOptions);

                }
                if (formsPin.ShowCallout)
                    m.ShowInfoWindow();
            }
        }

        void HandleMarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {

            e.Handled = true;
            var marker = e.Marker;

            if (marker.IsInfoWindowShown) // Always returns false, check
                marker.HideInfoWindow();
            else
                marker.ShowInfoWindow();

        }
    }
}