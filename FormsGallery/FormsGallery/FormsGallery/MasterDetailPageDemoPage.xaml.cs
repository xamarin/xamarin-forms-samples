
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
			// Set the BindingContext of the detail page.
			Detail.BindingContext = e.SelectedItem;

			// Show the detail page.
			IsPresented = false;
		}
	}
}
