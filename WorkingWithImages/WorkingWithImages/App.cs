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

            return new LocalImages();
//          return new LocalImagesXaml();
//          return new DownloadImages();
//			return new DownloadImagesXaml();
//			return new EmbeddedImages ();
//			return new EmbeddedImagesXaml ();

//			return new LoadingPlaceholder ();

		}
    }
}
