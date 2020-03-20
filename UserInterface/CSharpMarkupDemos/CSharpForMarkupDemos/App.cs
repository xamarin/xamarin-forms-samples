using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using CSharpForMarkupDemos.Views;
using CSharpForMarkupDemos.ViewModels;
using CSharpForMarkupDemos.Helpers;

namespace CSharpForMarkupDemos
{
    public class App : Application
    {
        public static new App Current => (App)Application.Current;

        RegistrationCodePage registrationCodePage;
        NestedListPage nestedListPage;
        AnimatedPage animatedPage;

        public MainViewModel MainViewModel { get; private set; }
        public RegistrationCodeViewModel RegistrationCodeViewModel { get; private set; }
        public NestedListViewModel NestedListViewModel { get; private set; }

        public App()
        {
            Device.SetFlags(new string[] { "Markup_Experimental" });

            Resources = Styles.Implicit;
            MainViewModel = new MainViewModel(this);
            MainPage = new NavigationPage(new MainPage());
        }

        public Task ContinueToRegistration()
        {
            if (RegistrationCodeViewModel == null)
                RegistrationCodeViewModel = new RegistrationCodeViewModel(this);
            if (registrationCodePage == null)
                registrationCodePage = new RegistrationCodePage();

            return TaskHelper.RunOnUIThread(() => MainPage.Navigation.PushAsync(registrationCodePage, true));
        }

        public Task ContinueToNestedList()
        {
            if (NestedListViewModel == null)
                NestedListViewModel = new NestedListViewModel(this);
            if (nestedListPage == null)
                nestedListPage = new NestedListPage();

            return TaskHelper.RunOnUIThread(() => MainPage.Navigation.PushAsync(nestedListPage, true));
        }

        public Task ContinueToAnimatedPage()
        {
            if (animatedPage == null)
                animatedPage = new AnimatedPage();

            return TaskHelper.RunOnUIThread(() => MainPage.Navigation.PushAsync(animatedPage, true));
        }

        public Task OpenUri(string uri) => Launcher.OpenAsync(new Uri(uri));

        public Task DisplayAlert(string title, string message, string cancel = "OK") => MainPage.DisplayAlert(title, message, cancel);

        public Task ReturnToPreviousView() => MainPage.Navigation.PopAsync(true);
    }
}
