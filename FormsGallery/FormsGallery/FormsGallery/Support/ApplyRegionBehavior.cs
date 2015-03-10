using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FormsGallery.Support
{
	public class ApplyRegionBehavior : Behavior<Map>
	{
		Map Map { get; set; }

		protected override void OnAttachedTo( Map bindable )
		{
			base.OnAttachedTo( bindable );

			Map = bindable;
			Refresh();
		}

		static void OnChanged( BindableObject bindable, object oldvalue, object newvalue )
		{
			var behavior = bindable as ApplyRegionBehavior;
			if ( behavior != null )
			{
				behavior.Refresh();
			}
		}

		void Refresh()
		{
			if ( Map != null && Map.IsVisible )
			{
				Map.MoveToRegion( new MapSpan( Position, Latitude, Longitude ) );
			}
		}

		public double Longitude
		{
			get { return (double)GetValue( LongitudeProperty ); }
			set { SetValue( LongitudeProperty, value ); }
		}	public static readonly BindableProperty LongitudeProperty = BindableProperty.Create( "Longitude", typeof(double), typeof (ApplyRegionBehavior), .01d );

		public double Latitude
		{
			get { return (double)GetValue( LatitudeProperty ); }
			set { SetValue( LatitudeProperty, value ); }
		}	public static readonly BindableProperty LatitudeProperty = BindableProperty.Create( "Latitude", typeof(double), typeof (ApplyRegionBehavior), .01d );

		public Position Position
		{
			get { return (Position)GetValue( PositionProperty ); }
			set { SetValue( PositionProperty, value ); }
		}	public static readonly BindableProperty PositionProperty = BindableProperty.Create( "Position", typeof(Position), typeof (ApplyRegionBehavior), new Position( 37.79762, -122.40181 ), propertyChanged: OnChanged );

	}
}