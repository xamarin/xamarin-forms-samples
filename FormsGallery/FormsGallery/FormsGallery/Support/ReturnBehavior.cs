using System;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public class ReturnBehavior : Behavior<MasterDetailPage>
	{
		readonly TapGestureRecognizer tap = new TapGestureRecognizer();

		View View { get; set; }

		public MasterDetailPage AssociatedObject { get; set; }

		protected override void OnAttachedTo( MasterDetailPage bindable )
		{
			base.OnAttachedTo( bindable );
			AssociatedObject = bindable;

			tap.Tapped += OnTapOnTapped;

			var content = bindable.Detail as ContentPage;
			View = content != null ? content.Content : null;
			Refresh( IsEnabled );
		}

		protected override void OnDetachingFrom( MasterDetailPage bindable )
		{
			base.OnDetachingFrom( bindable );
			AssociatedObject = null;

			tap.Tapped -= OnTapOnTapped;
			Refresh( false );
			View = null;
		}

		void OnTapOnTapped( object sender, EventArgs args )
		{
			AssociatedObject.IsPresented = true;
		}

		public bool IsEnabled
		{
			get { return (bool)GetValue( IsEnabledProperty ); }
			set { SetValue( IsEnabledProperty, value ); }
		}	public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create( "IsEnabled", typeof(bool), typeof (ReturnBehavior), true, propertyChanged: OnChanged );

		static void OnChanged( BindableObject bindable, object oldvalue, object newvalue )
		{
			var behavior = bindable as ReturnBehavior;
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