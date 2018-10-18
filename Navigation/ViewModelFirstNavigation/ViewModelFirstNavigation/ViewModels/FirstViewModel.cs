using System;
using System.Windows.Input;
using ViewModelFirstNavigation.Interfaces;
using Xamarin.Forms;

namespace ViewModelFirstNavigation.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public string PageTitle => "Start Page";
        public string GoToNextPageButtonText => "Push to next page";

        private readonly INavigator _navigator;

        public FirstViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ICommand NextPageCommand => new Command(() =>
        {
            _navigator.PushAsync<SecondViewModel>();
        });
    }
}
