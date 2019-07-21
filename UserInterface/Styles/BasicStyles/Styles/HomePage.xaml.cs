using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Styles
{
	public partial class HomePage : ContentPage
	{
        public ICommand NavigateCommand { get; private set; }

        public HomePage ()
		{
			InitializeComponent ();

            NavigateCommand = new Command<Type>(
                async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await Navigation.PushAsync(page);
                });
            BindingContext = this;
		}
	}
}

