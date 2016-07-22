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

			// C# examples - triggers are really designed for XAML
//			var csTab = new TabbedPage ();
//			csTab.Children.Add(new SimpleTriggerPage {Title = "Property", Icon="csharp.png"});
//			csTab.Children.Add(new RequiredFieldTriggerPage { Title = "Data", Icon="csharp.png"});
//			csTab.Children.Add(new NumericValidationTriggerPage { Title = "Valid", Icon="csharp.png"});
//			MainPage = csTab;


			// Xaml examples
			var xamlTab = new TabbedPage ();
			xamlTab.Children.Add(new PropertyTriggerXaml { Title = "Property", Icon="xaml.png"});
			xamlTab.Children.Add(new DataTriggerXaml { Title = "Data", Icon="xaml.png"});
			xamlTab.Children.Add(new EventTriggerXaml { Title = "Event", Icon="xaml.png"});
			xamlTab.Children.Add(new MultiTriggerXaml { Title = "Multi", Icon="xaml.png"});
			xamlTab.Children.Add(new EnterExitActionXaml { Title = "EnterExit", Icon="xaml.png"});

			MainPage = xamlTab;
		}
    }
}
