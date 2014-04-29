using System;
using Xamarin.QuickUI;

namespace Meetum.Views
{
    public class RootPage : MasterDetailPage
    {
        MapDisplayPage displayPage;
        OptionItem previousItem;

        public RootPage ()
        {
            Master = CreateMenuPage();
            Detail = new NavigationPage(new MapDisplayPage { Title = "Accounts" }) {
                Tint = Color.FromHex("5AA09B") 
            };
        }

        MapOptionsPage CreateMenuPage()
        {
            var page = new MapOptionsPage { Icon = "settings.png" };
            page.Menu.ItemSelected += (sender, e) => NavigateTo(e.Data as OptionItem);

            return page;
        }

        void NavigateTo (OptionItem option)
        {
            if (previousItem != null)
                previousItem.Selected = false;

            option.Selected = true;
            previousItem = option;

            var page = new MapDisplayPage();
            page.Title =  option.Title;

            if (displayPage == null)
                displayPage = page;

            Detail = new NavigationPage(page) {
                Tint = Color.FromHex("5AA09B"),               
            };

            IsPresented = false;

        }
    }
}

