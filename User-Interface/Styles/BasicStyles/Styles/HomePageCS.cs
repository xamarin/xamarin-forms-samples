using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Styles
{
	public class HomePageCS : ContentPage
	{
        public ICommand NavigateCommand { get; private set; }

        public HomePageCS ()
		{
            NavigateCommand = new Command<Type>(async (pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });
            BindingContext = this;

            Title = "Style demos";
            Content = new TableView
            {
                Intent = TableIntent.Menu,
                Root = new TableRoot
                {
                    new TableSection("Styles")
                    {
                        new TextCell { Text = "No styles", Command = NavigateCommand, CommandParameter = typeof(NoStylesPageCS) },
                        new TextCell { Text = "Explicit styles", Command = NavigateCommand, CommandParameter = typeof(ExplicitStylesPageCS) },
                        new TextCell { Text = "Implicit styles", Command = NavigateCommand, CommandParameter = typeof(ImplicitStylesPageCS) },
                        new TextCell { Text = "Application styles", Command = NavigateCommand, CommandParameter = typeof(ApplicationStylesPageCS) },
                        new TextCell { Text = "Style inheritance", Command = NavigateCommand, CommandParameter = typeof(StyleInheritancePageCS) },
                        new TextCell { Text = "Style classes", Command = NavigateCommand, CommandParameter = typeof(StyleClassPageCS) }
                    }
                }
            };
        }
	}
}
