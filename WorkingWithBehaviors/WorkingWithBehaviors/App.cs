using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithBehaviors
{
	public class App : Application
    {
		public App ()
        {
			//
			// NOTE: uncomment the relevant page that you'd like to test
			//


			// Xaml examples
			var xamlTab = new TabbedPage ();
			xamlTab.Children.Add(new NumericValidationXaml { Title = "Numeric", Icon="xaml.png"});

			MainPage = xamlTab;
		}
    }
}
