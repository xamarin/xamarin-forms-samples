using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OfflineCurrencyConverter.Shared;
using OfflineCurrencyConverter.Services.Navigation;

namespace OfflineCurrencyConverter.ViewModels
{
    public class BaseViewModel<T> : ReactiveObject, IInitializable<T>
    {
        protected SimpleNavigationService _navService = AppLocator.NavService;
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }
        
        public BaseViewModel()
        {

        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task StopAsync()
        {
            return Task.CompletedTask;
        }
    }
}