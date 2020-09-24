using System;
using Xamarin.Forms;

namespace FlyoutPageNavigation
{
    public class MainPageCS : FlyoutPage
    {
        FlyoutMenuPageCS flyoutPage;

        public MainPageCS()
        {
            flyoutPage = new FlyoutMenuPageCS();
            Flyout = flyoutPage;
            Detail = new NavigationPage(new ContactsPageCS());

            flyoutPage.ListView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                flyoutPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
