using System.Collections.Generic;
using MapOverlay;
using MapOverlay.Tizen;
using Tizen.Maps;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Tizen;
using Xamarin.Forms.Platform.Tizen;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.Tizen
{
    public class CustomMapRenderer : MapRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
               // Unsubscribe
            }
            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as global::Tizen.Maps.MapView;

                var coordinates = new List<Geocoordinates>();
                foreach (var position in formsMap.ShapeCoordinates)
                {
                    coordinates.Add(new Geocoordinates(position.Latitude, position.Longitude));
                }

                var polygon = new Polygon(coordinates, ElmSharp.Color.FromRgba(255,0,0,128));
                nativeMap.Add(polygon);

            }
        }
    }
}
