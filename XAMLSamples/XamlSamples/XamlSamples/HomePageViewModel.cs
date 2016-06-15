using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamlSamples
{
    class HomePageViewModel
    {
        public HomePageViewModel(Type pageType,
                             Action<Type> gotoExecute, 
                             Action<String> browseExecute)
        {
            this.PageType = pageType;
            this.PageName = pageType.Name;
            this.GoToCommand = new Command<Type>(gotoExecute);
            this.BrowseCommand = new Command<String>(browseExecute);
        }

        public Type PageType { private set; get; }

        public string PageName { private set; get; }

        public ICommand GoToCommand { private set; get; }

        public ICommand BrowseCommand { private set; get; }
    }
}
