using System.Linq;
using Xamarin.Forms;

using MobileCRM.Shared.Pages;
using MobileCRM.Models;


namespace MobileCRM.Shared.Pages
{
    public class RootPage : MasterDetailPage
    {
//        MainPage displayPage;
        OptionItem previousItem;

        public RootPage ()
        {
            
            var optionsPage = new MenuPage { Icon = "settings.png", Title = "menu" };
            
            optionsPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as OptionItem);

            Master = optionsPage;

            NavigateTo(optionsPage.Menu.ItemsSource.Cast<OptionItem>().First());
            //ShowLoginDialog();

      
        }

        async void ShowLoginDialog()
        {
            var page = new LoginPage();

            await Navigation.PushModalAsync(page);
        }

        void NavigateTo(OptionItem option)
        {
            if (previousItem != null)
                previousItem.Selected = false;

            option.Selected = true;
            previousItem = option;

            var displayPage = new MainPage { Title = option.Title };

         
            Detail = new NavigationPage(displayPage)
            {
              Tint = Helpers.Color.Blue.ToFormsColor(),
            };


            IsPresented = false;
        }
    }
}

