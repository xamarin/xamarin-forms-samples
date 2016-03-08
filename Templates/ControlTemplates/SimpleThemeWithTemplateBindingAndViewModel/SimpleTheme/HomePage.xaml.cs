using System;
using Xamarin.Forms;

namespace SimpleTheme
{
	public partial class HomePage : ContentPage
	{
		bool originalTemplate = true;
		ControlTemplate tealTemplate;
		ControlTemplate aquaTemplate;

		public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create ("HeaderText", typeof(string), typeof(HomePage), null);
		public static readonly BindableProperty FooterTextProperty = BindableProperty.Create ("FooterText", typeof(string), typeof(HomePage), null);

		public string HeaderText {
			get { return (string)GetValue (HeaderTextProperty); }
		}

		public string FooterText {
			get { return (string)GetValue (FooterTextProperty); }
		}

		public HomePage ()
		{
			InitializeComponent ();

			tealTemplate = (ControlTemplate)Application.Current.Resources ["TealTemplate"];
			aquaTemplate = (ControlTemplate)Application.Current.Resources ["AquaTemplate"];
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			originalTemplate = !originalTemplate;
			contentView.ControlTemplate = (originalTemplate) ? tealTemplate : aquaTemplate;
		}
	}
}

