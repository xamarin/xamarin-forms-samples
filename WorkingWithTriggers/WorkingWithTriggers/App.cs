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
//			csTab.Children.Add(new SimpleTriggerPage {Title = "Property", IconImageSource="csharp.png"});
//			csTab.Children.Add(new RequiredFieldTriggerPage { Title = "Data", IconImageSource="csharp.png"});
//			csTab.Children.Add(new NumericValidationTriggerPage { Title = "Valid", IconImageSource="csharp.png"});
//			MainPage = csTab;


			// Xaml examples
			var xamlTab = new TabbedPage ();
			xamlTab.Children.Add(new PropertyTriggerXaml { Title = "Property", IconImageSource="xaml.png"});
			xamlTab.Children.Add(new DataTriggerXaml { Title = "Data", IconImageSource="xaml.png"});
			xamlTab.Children.Add(new EventTriggerXaml { Title = "Event", IconImageSource="xaml.png"});
			xamlTab.Children.Add(new MultiTriggerXaml { Title = "Multi", IconImageSource="xaml.png"});
			xamlTab.Children.Add(new EnterExitActionXaml { Title = "EnterExit", IconImageSource="xaml.png"});

			MainPage = xamlTab;
		}
    }
}
