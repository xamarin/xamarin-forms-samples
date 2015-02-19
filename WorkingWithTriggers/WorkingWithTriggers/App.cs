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
			csTab.Children.Add(new SimpleTriggerPage {Title = "Property", Icon="csharp.png"});
			csTab.Children.Add(new RequiredFieldTriggerPage { Title = "Data", Icon="csharp.png"});
//			csTab.Children.Add(new NumericValidationTriggerPage { Title = "Valid", Icon="csharp.png"});

//			MainPage = csTab;


			// Xaml examples
			var xamlTab = new TabbedPage ();
			xamlTab.Children.Add(new SimpleTriggerXaml { Title = "Property", Icon="xaml.png"});
			xamlTab.Children.Add(new RequiredFieldDataTriggerXaml { Title = "Data", Icon="xaml.png"});
			xamlTab.Children.Add(new NumericValidationTriggerXaml { Title = "Event1", Icon="xaml.png"});
			xamlTab.Children.Add(new OnClickEventTriggerXaml { Title = "Event2", Icon="xaml.png"});

			MainPage = xamlTab;
		}
    }
}
