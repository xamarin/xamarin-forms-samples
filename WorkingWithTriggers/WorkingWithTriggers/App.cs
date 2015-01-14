using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithTriggers
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
			csTab.Children.Add(new SimpleTriggerPage {Title = "Simple", Icon="csharp.png"});
			csTab.Children.Add(new RequiredFieldTriggerPage { Title = "Req'd", Icon="csharp.png"});
//			csTab.Children.Add(new NumericValidationTriggerPage { Title = "Valid", Icon="csharp.png"});

//			MainPage = csTab;


			// Xaml examples
			var xamlTab = new TabbedPage ();
			xamlTab.Children.Add(new SimpleTriggerXaml { Title = "Simple", Icon="xaml.png"});
			xamlTab.Children.Add(new RequiredFieldDataTriggerXaml { Title = "Req'd", Icon="xaml.png"});
			xamlTab.Children.Add(new NumericValidationTriggerXaml { Title = "Valid", Icon="xaml.png"});
			xamlTab.Children.Add(new OnClickEventTriggerXaml { Title = "Event", Icon="xaml.png"});

			MainPage = xamlTab;
		}
    }
}
