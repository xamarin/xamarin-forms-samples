using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RssFeedWithImages
{
    public class App
    {
        public static Page GetMainPage()
        {
            // Create NavigationPage for navigation.
            return new NavigationPage(new RssFeedPage());
        }
    }
}
