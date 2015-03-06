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
}