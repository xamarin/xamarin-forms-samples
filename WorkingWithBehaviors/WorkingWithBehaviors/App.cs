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

			// C# examples
			var csTab = new TabbedPage ();
			//csTab.Children.Add(new SimpleTriggerPage {Title = "Simple", Icon="csharp.png"});

//			MainPage = csTab;


			// Xaml examples
			var xamlTab = new TabbedPage ();
			xamlTab.Children.Add(new NumericValidationXaml { Title = "Numeric", Icon="xaml.png"});
			xamlTab.Children.Add(new EmailValidationBehaviorXaml { Title = "Email", Icon="xaml.png"});

			MainPage = xamlTab;
		}
    }
}
