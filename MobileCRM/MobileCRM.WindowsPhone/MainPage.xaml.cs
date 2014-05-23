using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MobileCRM.WindowsPhone.Resources;
using Xamarin.Forms;
using Xamarin;
using MobileCRM.Shared.CustomViews;
using MobileCRM.Shared.Pages;

namespace MobileCRM.WindowsPhone
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();


            MobileCRMApp.Init(typeof(MobileCRMApp).Assembly);
			Forms.Init();
			FormsMaps.Init();

			// Set our view from the "main" layout resource
			Content = BuildView().ConvertPageToUIElement(this);
		}

		static Xamarin.Forms.Page BuildView()
		{
			return new RootPage();
		}

		// Sample code for building a localized ApplicationBar
		//private void BuildLocalizedApplicationBar()
		//{
		//    // Set the page's ApplicationBar to a new instance of ApplicationBar.
		//    ApplicationBar = new ApplicationBar();

		//    // Create a new button and set the text value to the localized string from AppResources.
		//    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
		//    appBarButton.Text = AppResources.AppBarButtonText;
		//    ApplicationBar.Buttons.Add(appBarButton);

		//    // Create a new menu item with the localized string from AppResources.
		//    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
		//    ApplicationBar.MenuItems.Add(appBarMenuItem);
		//}
	}
}