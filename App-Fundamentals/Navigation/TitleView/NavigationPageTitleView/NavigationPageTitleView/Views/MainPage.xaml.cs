using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NavigationPageTitleView
{
	public partial class MainPage : ContentPage
	{
        Page _originalRoot;

        public ICommand NavigateCommand { get; private set; }

        
		public MainPage()
		{
			InitializeComponent();

            NavigateCommand = new Command<Type>(async (pageType) => await NavigateToPage(pageType));
            BindingContext = this;
		}

        async Task NavigateToPage(Type pageType)
        {
            Type[] types = new Type[] { typeof(Command) };
            ConstructorInfo info = pageType.GetConstructor(types);
            if (info != null)
            {
                Page page = (Page)Activator.CreateInstance(pageType, new Command(RestoreOriginal));
                if (page is iOSExtendedTitleViewPage)
                {
                    page = new iOSNavigationPage(page);
                }
                else if (page is AndroidExtendedTitleViewPage)
                {
                    page = new AndroidNavigationPage(page);
                }
                SetRoot(page);
            }
            else
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            }
        }

        void SetRoot(Page page)
        {
            var app = Application.Current as App;
            if (app == null)
            {
                return;
            }

            _originalRoot = app.MainPage;
            app.SetMainPage(page);
        }

        void RestoreOriginal()
        {
            if (_originalRoot == null)
            {
                return;
            }

            var app = Application.Current as App;
            app?.SetMainPage(_originalRoot);
        }
	}
}
