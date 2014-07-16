using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithImages
{
    public class App
    {
        public static Page GetMainPage()
        {
			//
			// NOTE: uncomment the relevant page that you'd like to test
			//

			// HACK the NavigationPage has been added to get around the tint bug in Xamarin.Forms 1.2.1
			return new NavigationPage(new LocalImages());
//          return new NavigationPage(LocalImagesXaml());
//          return new NavigationPage(DownloadImages());
//			return new NavigationPage(DownloadImagesXaml());
//			return new NavigationPage(EmbeddedImages ());
//			return new NavigationPage(EmbeddedImagesXaml ());

//			return new NavigationPage(LoadingPlaceholder ());

		}
    }
}
