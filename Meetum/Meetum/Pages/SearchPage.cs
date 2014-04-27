using System;
using Xamarin.QuickUI;

namespace Meetum.Views
{
    public class SearchPage : MasterDetailPage
    {
        public SearchPage ()
        {
            Master = new CustomerMapOptionsView { Icon = "settings.png" };
            Detail = new NavigationPage(new CustomerMapDisplayView { Title = "Customers Nearby" }) {
                Tint = Color.FromHex("5AA09B") 
            };
        }
    }
}

