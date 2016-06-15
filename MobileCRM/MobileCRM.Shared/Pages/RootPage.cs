using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileCRM.Shared.Pages;
using MobileCRM.Models;
using MobileCRM.Services;


namespace MobileCRM.Shared.Pages
{
    public class RootPage : MasterDetailPage
    {
        OptionItem previousItem;

        public RootPage ()
        {
            
            var optionsPage = new MenuPage { Icon = "settings.png", Title = "menu" };
            
            optionsPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as OptionItem);

            Master = optionsPage;

            NavigateTo(optionsPage.Menu.ItemsSource.Cast<OptionItem>().First());

            ShowLoginDialog();    
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

            var displayPage = PageForOption(option);

#if WINDOWS_PHONE
            Detail = new ContentPage();//work around to clear current page.
#endif
			var color = Helpers.Color.Blue.ToFormsColor ();
			Detail = new NavigationPage (displayPage) {
				BarBackgroundColor = color,
				BarTextColor = color
			};

            IsPresented = false;
        }

		Page PageForOption (OptionItem option)
		{
			var builder = new MasterPageBuilder ();
			if (option.Title == "Contacts")
				return builder.BuildContacts (option);
			if (option.Title == "Leads")
				return builder.BuildLeads (option);
			if (option.Title == "Accounts")
				return builder.BuildAccounts (option);
			if (option.Title == "Opportunities")
				return builder.BuildOpportunities (option);

			throw new NotImplementedException (string.Format ("Unknown menu option: {0}", option.Title));
		}
    }
}

