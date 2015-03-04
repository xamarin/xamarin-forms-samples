using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsGallery
{
	public partial class TableViewMenuDemoPage
	{
		readonly ICommand navigateCommand;

		public TableViewMenuDemoPage()
		{
			InitializeComponent();

			navigateCommand = new Command<Type>( async pageType =>
			{
				Page page = (Page)Activator.CreateInstance( pageType );
				await this.Navigation.PushAsync( page );
			} );
		}

		public ICommand NavigateCommand
		{
			get { return navigateCommand; }
		}
	}
}
