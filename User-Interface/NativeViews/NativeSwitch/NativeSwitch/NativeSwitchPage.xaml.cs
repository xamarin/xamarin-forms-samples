using Xamarin.Forms;

namespace NativeSwitch
{
	public partial class NativeSwitchPage : ContentPage
	{
		public NativeSwitchPage()
		{
			InitializeComponent();
			BindingContext = new NativeSwitchPageViewModel();
		}
	}
}
