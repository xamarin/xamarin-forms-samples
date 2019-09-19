
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public partial class PolygonsPage : ContentPage
    {
        Polyline polyline;
        Polygon polygon;

        public PolygonsPage()
        {
            InitializeComponent();

            // polygon is a collection of points representing
            // the xamarin hexagon shape
            polygon = new Polygon
            {
                StrokeColor = Color.FromHex("#3498DB"),
                StrokeWidth = 15,
                FillColor = Color.FromHex("#883498DB"),
                Geopath =
                {
                    new Position(46.1037086, -105.0732425),
                    new Position(41.5743612, -108.6328128),
                    new Position(36.5978889, -104.9414065),
                    new Position(36.6331619, -97.69043),
                    new Position(41.5414775, -94.0869144),
                    new Position(46.1037086, -97.5585941),
                    new Position(46.1037086, -105.0732425)
                }
            };

            // polyline is a collection of points representing
            // the xamarin X shape
            polyline = new Polyline
            {
                StrokeColor = Color.White,
                StrokeWidth = 15,
                Geopath =
                {
                    new Position(41.0627859, -101.6455081),
                    new Position(39.0789079, -103.0078128),
                    new Position(39.0789079, -104.3261722),
                    new Position(41.5250294, -102.4804691),
                    new Position(43.9453722, -104.4140628),
                    new Position(43.9453722, -103.0957034),
                    new Position(41.6893221, -101.2500003),
                    new Position(44.00862, -99.4042972),
                    new Position(44.00862, -98.3496097),
                    new Position(41.6236552, -100.0634769),
                    new Position(39.0789079, -98.2177737),
                    new Position(39.1130135, -99.5361331),
                    new Position(41.0959119, -100.8105472)
                }
            };

            Map.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(36.61, -100),Distance.FromMiles(1500)));
        }

        private void MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {

        }

        private void AddPolylineClicked(object sender, System.EventArgs e)
        {
            if (!Map.MapElements.Contains(polyline))
            {
                // inserting at zero ensures polyline draws on top
                // of any other MapElements
                Map.MapElements.Insert(0, polyline);
            }
        }

        private void AddPolygonClicked(object sender, System.EventArgs e)
        {
            if (!Map.MapElements.Contains(polygon))
            {
                Map.MapElements.Add(polygon);
            }
        }

        private void ClearClicked(object sender, System.EventArgs e)
        {
            Map.MapElements.Remove(polygon);
            Map.MapElements.Remove(polyline);
        }
    }
}