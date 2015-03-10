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
