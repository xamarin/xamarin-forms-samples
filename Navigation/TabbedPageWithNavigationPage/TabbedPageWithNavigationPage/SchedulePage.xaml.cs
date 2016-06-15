using System;
using Xamarin.Forms;

namespace TabbedPageWithNavigationPage
{
	public partial class SchedulePage : ContentPage
	{
		public SchedulePage ()
		{
			InitializeComponent ();
		}

		async void OnUpcomingAppointmentsButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new UpcomingAppointmentsPage ());
		}
	}
}

