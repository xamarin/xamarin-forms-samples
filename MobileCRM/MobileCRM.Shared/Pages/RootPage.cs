using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms.Maps;
using Meetup.Shared.Pages;


namespace MobileCRM.Views
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
                Tint = Meetup.Shared.Helpers.Color.Tint.ToFormsColor(),
            };

            IsPresented = false;
        }
    }
}

