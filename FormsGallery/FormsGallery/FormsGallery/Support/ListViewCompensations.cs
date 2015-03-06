using Xamarin.Forms;

namespace FormsGallery.Support
{
	public static class ListViewCompensations
	{
		public static readonly BindableProperty AssignProperty = BindableProperty.CreateAttached( "Assign", typeof(object), typeof (ListViewCompensations), default(object), propertyChanged: OnAssignChanged );

		static void OnAssignChanged( BindableObject bindable, object oldvalue, object newvalue )
		{
			var view = bindable as ListView;
			if ( view != null && view.SelectedItem != newvalue && newvalue != null )
			{
				view.SelectedItem = newvalue;
			}
		}

		public static object GetAssign( ListView target )
		{
			return target.GetValue( AssignProperty );
		}

		public static void SetAssign( ListView target, object value )
		{
			target.SetValue( AssignProperty, value );
		}
	}
}