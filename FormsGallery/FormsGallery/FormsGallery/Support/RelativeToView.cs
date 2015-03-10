using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery.Support
{
	public abstract class RelativeToView : IMarkupExtension
	{
		protected RelativeToView()
		{
			Factor = 1;
		}

		public string ElementName { get; set; }

		public double Factor { get; set; }

		public double Constant { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			var element = new ReferenceExtension { Name = ElementName }.ProvideValue( serviceProvider ) as View;
			if ( element != null )
			{
				var result = Constraint.RelativeToView( element, ( layout, view ) => DeterminePosition( view ) + Constant );
				return result;
			}
			return null;
		}

		protected virtual double DeterminePosition( VisualElement view )
		{
			var result = DetermineStart( view ) + DetermineExtent( view ) * Factor;
			return result;
		}

		protected abstract double DetermineExtent( VisualElement view );

		protected abstract double DetermineStart( VisualElement view );
	}
}