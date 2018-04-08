using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TableViewSamples
{
    public class App : Application
    {
        public App()
        {
			bool useXaml = true; //set to your desired preference
			var tabs = new TabbedPage();

			if(useXaml)
			{
				tabs.Children.Add(new DataIntentXaml());
				tabs.Children.Add(new FormIntentXaml());
				tabs.Children.Add(new MenuIntentXaml());
				tabs.Children.Add(new SettingsIntentXaml());
				tabs.Children.Add(new SwitchCellDemoXaml());
				tabs.Children.Add(new EntryCellDemoXaml());
			} else{
				tabs.Children.Add(new DataIntentCode());
				tabs.Children.Add(new FormIntentCode());
				tabs.Children.Add(new MenuIntentCode());
				tabs.Children.Add(new SettingsIntentCode());
				tabs.Children.Add(new SwitchCellDemoCode());
				tabs.Children.Add(new EntryCellDemoCode());
			}
				
			MainPage = tabs;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
