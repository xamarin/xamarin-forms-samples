using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsGallery
{
	 // Although this page is actually a ContentPage, it can 
    //  function as a NavigationPage because the HomePage
    //  is launched as an ApplicationPage in App. 
	public partial class NavigationPageDemoPage
	{
		readonly ICommand navigateCommand;

		public NavigationPageDemoPage()
		{
			navigateCommand = new Command<Type>( async pageType =>
			{
				Page page = (Page)Activator.CreateInstance( pageType );
				await this.Navigation.PushAsync( page );
			} );

			InitializeComponent();
		}

		public ICommand NavigateCommand
		{
			get { return navigateCommand; }
		}
	}
}
