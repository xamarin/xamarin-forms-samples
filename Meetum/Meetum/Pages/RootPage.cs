using System;
using Xamarin.QuickUI;

namespace Meetum.Views
{
    public class RootPage : MasterDetailPage
    {
        public RootPage ()
        {
            Master = new MapOptionsPage { Icon = "settings.png" };
            Detail = new NavigationPage(new MapDisplayPage { Title = "Accounts" }) {
                Tint = Color.FromHex("5AA09B") 
            };
        }
    }
}

