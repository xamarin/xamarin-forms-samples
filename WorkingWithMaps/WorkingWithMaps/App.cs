using Xamarin.Forms;

/*
Glyphish icons from
	http://www.glyphish.com/
under
	http://creativecommons.org/licenses/by/3.0/us/
support them by buying the full set / Retina versions
*/

namespace WorkingWithMaps
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
