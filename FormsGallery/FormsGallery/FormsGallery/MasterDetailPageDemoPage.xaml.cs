
using System;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class MasterDetailPageDemoPage
	{
		public MasterDetailPageDemoPage()
		{
			InitializeComponent();
		}

		void ListView_OnItemSelected( object sender, SelectedItemChangedEventArgs e )
		{
			// Show the detail page.
			if ( e.SelectedItem != null )
			{
				IsPresented = false;
			}
		}

		void MasterDetailPageDemoPage_OnIsPresentedChanged( object sender, EventArgs e )
		{
			if ( IsPresented )
			{
				Items.SelectedItem = null;
			}
		}
	}
}
