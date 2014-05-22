using Xamarin.Forms;
using System.Collections.ObjectModel;
using Meetup.Shared.Pages;

namespace MobileCRM.Views
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            BackgroundColor = Color.Black;

            this.Children.Add(new MapPage());
            this.Children.Add(new CustomersPages());
        }
    }
}
