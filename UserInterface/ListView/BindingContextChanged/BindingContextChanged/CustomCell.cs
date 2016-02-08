using Xamarin.Forms;

namespace BindingContextChanged
{
	public class CustomCell : ViewCell
	{
		public static readonly BindableProperty TitleProperty = 
			BindableProperty.Create (propertyName:"Title", 
				returnType:typeof(string), 
				declaringType:typeof(CustomCell), 
				defaultValue:"Test");

		public string Title {
			get { return(string)GetValue (TitleProperty); }
			set { SetValue (TitleProperty, value); }
		}

		//		public CustomCell ()
		//		{
		//			View = new Label { Text = Title };
		//		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();

			if (BindingContext != null) {
				View = new Label { Text = Title };
			}
		}
	}
}
