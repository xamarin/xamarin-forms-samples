using System;
using System.Collections;
using System.Linq;
using Xamarin.Forms;

namespace FormsGallery.Support
{
	public static class PickerCompensations
	{
		public static readonly BindableProperty ItemsProperty = BindableProperty.CreateAttached( "Items", typeof(IEnumerable), typeof (PickerCompensations), default(IEnumerable), propertyChanged: OnItemsChanged );

		static void OnItemsChanged( BindableObject bindable, object oldvalue, object newvalue )
		{
			var picker = bindable as Picker;
			var enumerable = newvalue as IEnumerable;
			if ( picker != null && enumerable != null )
			{
				picker.Items.Clear();
				foreach ( var item in enumerable.Cast<object>() )
				{
					picker.Items.Add( item.ToString() );
				}
			}
		}

		public static IEnumerable GetItems( Picker target )
		{
			return (IEnumerable)target.GetValue( ItemsProperty );
		}

		public static void SetItems( Picker target, IEnumerable value )
		{
			target.SetValue( ItemsProperty, value );
		}
	}

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