using Xamarin.Forms;
using System.Collections.ObjectModel;
using MobileCRM.Shared.Pages;

namespace MobileCRM.Shared.Pages
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            this.Children.Add(new MapPage());
            this.Children.Add(new CustomersPages());
        }
    }
}
