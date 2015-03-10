using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LabelledSections
{
	public class App : Application
    {
        public App()
        {
			var tabs = new TabbedPage ();

			tabs.Children.Add(new LabelledSectionPage {Title = "C#" });
			tabs.Children.Add(new LabelledSectionXaml {Title = "XAML" });

			MainPage = tabs;
        }
    }
}
