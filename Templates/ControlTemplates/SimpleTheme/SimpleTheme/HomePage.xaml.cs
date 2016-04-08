using System;
using Xamarin.Forms;

namespace SimpleTheme
{
	public partial class HomePage : ContentPage
	{
		bool originalTemplate = true;
		ControlTemplate tealTemplate;
		ControlTemplate aquaTemplate;

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

