using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapOverlay
{
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();

			customMap.ShapeCoordinates.Add (new Position (37.797513, -122.402058));
			customMap.ShapeCoordinates.Add (new Position (37.798433, -122.402256));
			customMap.ShapeCoordinates.Add (new Position (37.798582, -122.401071));
			customMap.ShapeCoordinates.Add (new Position (37.797658, -122.400888));

			customMap.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (37.79752, -122.40183), Distance.FromMiles (0.1)));
		}
	}
}
