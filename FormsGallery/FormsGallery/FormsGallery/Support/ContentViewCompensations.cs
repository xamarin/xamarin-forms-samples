using Xamarin.Forms;

namespace FormsGallery.Support
{
	public static class ContentViewCompensations
	{
		public static readonly BindableProperty ContentProperty = BindableProperty.CreateAttached( "Content", typeof(View), typeof (ContentViewCompensations), default(View), propertyChanged: OnContentChanged );

		static void OnContentChanged( BindableObject bindable, object oldvalue, object newvalue )
		{
			var view = bindable as ContentView;
			if ( view != null )
			{
				view.Content = newvalue as View;
			}
		}

		public static View GetContent( ContentView target )
		{
			return (View)target.GetValue( ContentProperty );
		}

		public static void SetContent( ContentView target, View value )
		{
			target.SetValue( ContentProperty, value );
		}
	}
}