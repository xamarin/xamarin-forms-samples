using System;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class ButtonDemoPage
	{
		readonly ICommand command;

		public ButtonDemoPage()
		{
			command = new Command( () => Clicks++ );
			InitializeComponent();
		}

		public int Clicks
		{
			get { return (int)GetValue( ClicksProperty ); }
			set { SetValue( ClicksProperty, value ); }
		}	public static readonly BindableProperty ClicksProperty = BindableProperty.Create( "Clicks", typeof(int), typeof (ButtonDemoPage), default(int) );

		public ICommand Command
		{
			get { return command; }
		}
	}
}
