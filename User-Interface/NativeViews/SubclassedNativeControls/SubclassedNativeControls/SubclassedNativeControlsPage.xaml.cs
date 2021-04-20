using Xamarin.Forms;

namespace SubclassedNativeControls
{
	public partial class SubclassedNativeControlsPage : ContentPage
	{
		public SubclassedNativeControlsPage()
		{
			InitializeComponent();
			BindingContext = new SubclassedNativeControlsPageViewModel();
		}
	}
}
