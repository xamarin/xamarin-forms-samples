using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace XamlSamples
{

    public class App : Application // superclass new in 1.3
    {
        public App()
        {
            MainPage = new NavigationPage(new XamlSamples.HomePage());
        }
    }
}