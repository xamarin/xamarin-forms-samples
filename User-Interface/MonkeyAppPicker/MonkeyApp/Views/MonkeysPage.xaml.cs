using Xamarin.Forms;

namespace MonkeyApp
{
	public partial class MonkeysPage : ContentPage
	{
		public MonkeysPage()
		{
			InitializeComponent();
			BindingContext = new MonkeysPageViewModel();
		}
	}
}
