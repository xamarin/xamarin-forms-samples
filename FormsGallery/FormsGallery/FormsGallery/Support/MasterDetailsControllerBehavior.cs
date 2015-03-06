using System;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class MasterDetailsControllerBehavior : Behavior<MasterDetailPage>
	{
		readonly TapGestureRecognizer tap = new TapGestureRecognizer();

		View View { get; set; }

		public MasterDetailPage AssociatedObject { get; private set; }

		protected override void OnAttachedTo( MasterDetailPage bindable )
		{
			base.OnAttachedTo( bindable );
			AssociatedObject = bindable;

			tap.Tapped += OnClearDetails;

			var content = bindable.Detail as ContentPage;
			View = content != null ? content.Content : null;
			Refresh( IsEnabled );
			
			bindable.Master.Appearing += OnClearDetails;
		}

		void OnClearDetails( object sender, EventArgs eventArgs )
		{
			SelectedDetails = null;
		}

		protected override void OnDetachingFrom( MasterDetailPage bindable )
		{
			base.OnDetachingFrom( bindable );
			AssociatedObject = null;

			tap.Tapped -= OnClearDetails;
			Refresh( false );
			View = null;
		}

		/*void OnTapOnTapped( object sender, EventArgs args )
		{
			AssociatedObject.IsPresented = true;
		}*/

		public object SelectedDetails
		{
			get { return (object)GetValue( SelectedDetailsProperty ); }
			set { SetValue( SelectedDetailsProperty, value ); }
		}	public static readonly BindableProperty SelectedDetailsProperty = BindableProperty.Create( "SelectedDetails", typeof(object), typeof (MasterDetailsControllerBehavior), default(object) );

		public bool IsEnabled
		{
			get { return (bool)GetValue( IsEnabledProperty ); }
			set { SetValue( IsEnabledProperty, value ); }
		}	public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create( "IsEnabled", typeof(bool), typeof (MasterDetailsControllerBehavior), true, propertyChanged: OnChanged );

		static void OnChanged( BindableObject bindable, object oldvalue, object newvalue )
		{
			var behavior = bindable as MasterDetailsControllerBehavior;
			if ( behavior != null )
			{
				behavior.Refresh( behavior.IsEnabled );
			}
		}

		void Refresh( bool enabled )
		{
			if ( View != null )
			{
				View.GestureRecognizers.Remove( tap );
				if ( enabled )
				{
					View.BackgroundColor = Color.Transparent;
					View.GestureRecognizers.Add( tap );
				}
			}
		}
	}
}