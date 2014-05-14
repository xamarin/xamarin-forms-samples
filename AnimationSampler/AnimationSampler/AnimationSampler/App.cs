using System;
using Xamarin.Forms;

namespace AnimationSampler
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new NavigationPage(new HomePage());
        }
    }
}
