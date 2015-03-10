using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class PickerDemoPage
	{
		public PickerDemoPage()
		{
			InitializeComponent();
		}

		public ICollection<NamedColor> Colors
		{
			get { return (ICollection<NamedColor>)BindingContext; }
			set { BindingContext = value; }
		}

		public Color SelectedColor
		{
			get { return (Color)GetValue( SelectedColorProperty ); }
			set { SetValue( SelectedColorProperty, value ); }
		}	public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create( "SelectedColor", typeof(Color), typeof (PickerDemoPage), default(Color) );

		void Picker_OnSelectedIndexChanged( object sender, EventArgs e )
		{
			SelectedColor = Picker.SelectedIndex == -1 ? Color.Default : Colors.ElementAt( Picker.SelectedIndex ).Color;
		}
	}
}
