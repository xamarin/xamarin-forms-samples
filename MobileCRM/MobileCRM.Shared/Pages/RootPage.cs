using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms.Maps;
using MobileCRM.Shared.Pages;
using MobileCRM.Shared.Models;


namespace MobileCRM.Shared.Pages
{
    public class RootPage : MasterDetailPage
    {
        MainPage displayPage;
        OptionItem previousItem;

        public RootPage ()
        {
            
            var optionsPage = new MenuPage { Icon = "settings.png", Title = "settings" };
            
            optionsPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as OptionItem);

            Master = optionsPage;

            ShowLoginDialog();

            NavigateTo(optionsPage.Menu.ItemSource.Cast<OptionItem>().First());
      
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

            displayPage = new MainPage { Title = option.Title };

         
            Detail = new NavigationPage(displayPage)
            {
              Tint = Helpers.Color.Blue.ToFormsColor(),
            };


            IsPresented = false;
        }
    }
}

