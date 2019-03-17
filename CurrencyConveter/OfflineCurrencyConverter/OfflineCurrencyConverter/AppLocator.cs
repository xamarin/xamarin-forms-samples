using CurrencyConverterService;
using CurrencyLocalData;
using CurrencyLocalData.Entities;
using OfflineCurrencyConverter.Services.Abstractions;
using OfflineCurrencyConverter.Services.Navigation;
using OfflineCurrencyConverter.Shared;
using OfflineCurrencyConverter.ViewModels;
using OfflineCurrencyConverter.Views;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OfflineCurrencyConverter
{
    public class AppLocator
    {
        public static IInitializable<MainPage> MainViewModel => Locator.CurrentMutable.GetService<MainViewModel<MainPage>>();
        public static ICurrencyConverter CurrencyConverter => Locator.CurrentMutable.GetService<CurrencyConverter>();
        public static IDataAccessor<GlobalCurrencies> GlobalCurrenciesDataAccessor => Locator.CurrentMutable.GetService<GlobalCurrenciesDataAccessor>();
        public static IDataAccessor<KeyValueCurrencyQuery> KeyValueCurrencyQueryDataAccessor => Locator.CurrentMutable.GetService<KeyValueCurrencyQueryDataAccessor>();
        public static SimpleNavigationService NavService => Locator.Current.GetService<SimpleNavigationService>();
        public static ShareAppPopupViewModel<ShareAppPopup> ShareAppPopupViewModel => Locator.CurrentMutable.GetService<ShareAppPopupViewModel<ShareAppPopup>>();
        public AppLocator()
        {
            string dataStore = DependencyService.Get<IDataStore>().GetDataStore();

            Locator.CurrentMutable.Register(() => new GlobalCurrenciesDataAccessor(dataStore));
            Locator.CurrentMutable.Register(() => new KeyValueCurrencyQueryDataAccessor(dataStore));
            Locator.CurrentMutable.Register(() => new CurrencyConverter());
            Locator.CurrentMutable.Register(() => new MainViewModel<MainPage>(CurrencyConverter, 
                KeyValueCurrencyQueryDataAccessor, GlobalCurrenciesDataAccessor));
            Locator.CurrentMutable.Register(() => new SimpleNavigationService());
            Locator.CurrentMutable.Register(() => new ShareAppPopupViewModel<ShareAppPopup>());
        }
    }
}
