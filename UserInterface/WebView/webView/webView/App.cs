using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace webView
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            TabbedPage x = new TabbedPage();
            NavigationPage navDemo = new NavigationPage() { Title = "Navigation Demo" };
            navDemo.PushAsync(new NavigationStart());
            x.Children.Add(navDemo);
            NavigationPage loadDemo = new NavigationPage() { Title = "Loading Demo" };
            loadDemo.PushAsync(new loadingDemo());
            x.Children.Add(loadDemo);
            MainPage = x;
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
