using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WebViewSample
{
    public class App : Application
    {
        public App()
        {
			var tabs = new TabbedPage ();
			var navPage = new NavigationPage () {Title="App Content"};
			tabs.Children.Add (navPage);

			bool useXaml = false; //change this to use the code implementation

			if (useXaml) {
				
				navPage.PushAsync (new LinkToInAppXaml ());
				tabs.Children.Add (new LoadingLabelXaml ());
			} else {
				navPage.PushAsync (new LinkToInAppCode ());
				tabs.Children.Add (new LoadingLabelCode ());
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
