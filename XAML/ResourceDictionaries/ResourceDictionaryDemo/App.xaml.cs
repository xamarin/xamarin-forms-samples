using Xamarin.Forms;

namespace ResourceDictionaryDemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();
			MainPage = new NavigationPage(new HomePage());
		}
	}
}

