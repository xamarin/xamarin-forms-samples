using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation (XamlCompilationOptions.Compile)]
namespace ResourceDictionaryDemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();
			MainPage = new NavigationPage (new HomePage ()) { BarBackgroundColor = (Color)Application.Current.Resources ["PageBackgroundColor"]	};
		}
	}
}

