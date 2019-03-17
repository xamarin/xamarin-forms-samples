using CurrencyConverterService;
using CurrencyLocalData;
using CurrencyLocalData.Entities;
using OfflineCurrencyConverter.Models;
using OfflineCurrencyConverter.Services.Navigation;
using OfflineCurrencyConverter.Shared;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OfflineCurrencyConverter.ViewModels
{
    public class MainViewModel<T> : BaseViewModel<T>
    {
        /// <summary>
        /// This attribute will be used to query the conversion service 
        /// Available online.
        /// </summary>
        ICurrencyConverter _currencyConverter;
        /// <summary>
        /// These attributes are used to access
        /// currencies in the offline databases(LiteDB)
        /// </summary>
        IDataAccessor<KeyValueCurrencyQuery> _keyValueStore;
        IDataAccessor<GlobalCurrencies> _globalCurrenciesStore;

        ObservableCollection<Currency> _currencies;
        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set => this.RaiseAndSetIfChanged(ref _currencies, value);
        }
        ObservableCollection<string> _stringCurrencies;
        public ObservableCollection<string> StringCurrencies
        {
            get => _stringCurrencies;
            set => this.RaiseAndSetIfChanged(ref _stringCurrencies, value);
        }

        public ICommand ConvertCommand { get; set; }
        public ICommand ShareCommand { get; set; }
        public ICommand PreviousConversionsCommand { get; set; }

        private double _amount;
        public double AmountToConvert
        {
            get { return _amount; }
            set { this.RaiseAndSetIfChanged(ref _amount, value); }
        }

        private double _convertedAmount;
        public double ConvertedAmount
        {
            get { return _convertedAmount; }
            set { this.RaiseAndSetIfChanged(ref _convertedAmount, value); }
        }
        
        /// <summary>
        /// The currency selected in the from drop down
        /// </summary>
        public Currency SelectedFromCurrency{ get; set; }
        
        /// <summary>
        /// The currency selected in the To drop down
        /// </summary>
        public Currency SelectedToCurrency{ get; set; }

        private string _fromCurrencySymbol;
        public string FromCurrencySymbol
        {
            get { return _fromCurrencySymbol; }
            set { this.RaiseAndSetIfChanged(ref _fromCurrencySymbol , value); }
        }
        private string _toCurrencySymbol;
        public string ToCurrencySymbol
        {
            get { return _toCurrencySymbol; }
            set { this.RaiseAndSetIfChanged(ref _toCurrencySymbol, value); }
        }

        /// <summary>
        /// This is to show the Results label on the UI or Not
        /// </summary>
        readonly ObservableAsPropertyHelper<bool> _canShowResult;
        public bool CanShowResultLabel => _canShowResult.Value;


        /// <summary>
        /// The index of the currency from which we are converting 
        /// </summary>
        private int _fromCurrencyIndex;
        public int FromCurrencyIndex
        {
            get { return _fromCurrencyIndex; }
            set {this.RaiseAndSetIfChanged(ref _fromCurrencyIndex, value); }
        }

        /// <summary>
        /// The index of the currency to which we are converting 
        /// </summary>
        private int _toCurrencyIndex;
        public int ToCurrencyIndex
        {
            get { return _toCurrencyIndex; }
            set { this.RaiseAndSetIfChanged(ref _toCurrencyIndex, value); }
        }

        private ObservableCollection<Conversion> _conversion;
        public ObservableCollection<Conversion> Conversions
        {
            get { return _conversion; }
            set { this.RaiseAndSetIfChanged(ref _conversion, value); }
        }
        
        string _currentQuery;
        double _currentQueryAmount;

        public MainViewModel(ICurrencyConverter currencyConverter, 
            IDataAccessor<KeyValueCurrencyQuery> keyValStore, IDataAccessor<GlobalCurrencies> globalCurStore)
        {
            _keyValueStore = keyValStore;
            _globalCurrenciesStore = globalCurStore;
            _currencyConverter = currencyConverter;
            Currencies = new ObservableCollection<Currency>();
            StringCurrencies = new ObservableCollection<string>();
            Conversions = new ObservableCollection<Conversion>();
            
            ConvertCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                if(!IsBusy)
                {
                    try
                    {
                        IsBusy = true;

                        var from = SelectedFromCurrency;
                        var to = SelectedToCurrency;

                        if (from.Id == to.Id)
                        {
                            //IF user converts for identical currency, display the same result
                            ConvertedAmount = AmountToConvert;
                            IsBusy = false;
                            return;
                        }

                        _currentQuery = $"{from.Id}_{to.Id}";
                        var kvs = _keyValueStore.PersonalizedQuery(kv => kv.KeyValue.First().Key == _currentQuery).Result;
                        
                        if (kvs.Any())
                        {
                            //If the last time this conversion index was updated is more than 5 days ago, update it again
                            if ((DateTime.Now - kvs.First().LastUpdate) > TimeSpan.FromDays(1))
                            {
                                await UpdateCurrencyConversionRate(kvs, from, to);
                            }
                            else
                            {
                                _currentQueryAmount = kvs.First().KeyValue.First().Value;
                                ConvertedAmount = _currentQueryAmount * AmountToConvert;
                            }
                        }
                        else
                        {
                            var qAmnt = await _currencyConverter.GetConvertQuerryAsync(from.Id, to.Id);
                            var dic = new Dictionary<string, double>();
                            dic.Add(qAmnt.Key, qAmnt.Value);
                            await _keyValueStore.Create(new KeyValueCurrencyQuery { KeyValue = dic, LastUpdate = DateTime.Now });
                            _currentQueryAmount = qAmnt.Value;
                            ConvertedAmount = qAmnt.Value * AmountToConvert;
                        }
                        
                        IsBusy = false;
                    }
                    catch (HttpRequestException e)
                    {
                        await _navService.NavigateToNoInternetPopup();
                        IsBusy = false;
                        Debug.WriteLine(e);
                    }
                }

            }, (this).WhenAnyValue(x => x.AmountToConvert, amt => amt > 0));

            ShareCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _navService.NavigateToSharePopup();
            });

            PreviousConversionsCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                if (Conversions.Any())
                    await _navService.NavigateToPreviousConversionsPopup(Conversions);
            });

            //Determines if the result label can be shown on the UI or not
            this.WhenAnyValue(v => v.ConvertedAmount, amt => amt > 0)
                .ToProperty(this, x => x.CanShowResultLabel, out _canShowResult);

            this.WhenAnyValue(t => t.FromCurrencyIndex, i => Currencies.Count < 1 ? null: Currencies[i])
                .Subscribe(async cur =>
                {
                    if (cur != null)
                    {
                        SelectedFromCurrency = cur;
                        FromCurrencySymbol = cur.CurrencySymbol ?? cur.Id;
                        MakeQueryStringAndAmount();
                        await RealtimeConversion();
                    }
                });
            this.WhenAnyValue(t => t.ToCurrencyIndex, i => Currencies.Count < 1 ? null : Currencies[i])
                .Subscribe(async cur =>
                {
                    if (cur != null)
                    {
                        SelectedToCurrency = cur;
                        ToCurrencySymbol = cur.CurrencySymbol ?? cur.Id;
                        MakeQueryStringAndAmount();
                        await RealtimeConversion();
                    }
                });

            this.WhenAnyValue(v => v.AmountToConvert)
                .Subscribe(async amt =>
                {
                    await RealtimeConversion();
                    MakeQueryStringAndAmount();
                });

            //Delay 2 seconds after the amount converted is set before updating the list of converted currencies
            this.WhenAnyValue(x => x.ConvertedAmount)
                .Where(amt => amt > 0)
                .Throttle(TimeSpan.FromSeconds(2))
                .Subscribe(amt =>
                {
                    if (amt > 0)
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Conversions.Add(new Conversion
                            {
                                CurrencyFromSymbol = SelectedFromCurrency.CurrencySymbol ?? SelectedFromCurrency.Id,
                                CurrencyToSymbol = SelectedToCurrency.CurrencySymbol ?? SelectedToCurrency.Id,
                                FromAmount = AmountToConvert,
                                ToAmount = amt,
                                ToStringText = $"({SelectedFromCurrency.CurrencySymbol ?? SelectedFromCurrency.Id}){SelectedFromCurrency.CurrencyName}" +
                        $"  {"To".Translate()}  ({SelectedToCurrency.CurrencySymbol ?? SelectedToCurrency.Id}){SelectedToCurrency.CurrencyName}"
                            });
                        });
                });
        }

        async Task UpdateCurrencyConversionRate(IEnumerable<KeyValueCurrencyQuery> kvs, Currency from, Currency to)
        {
            var currentKv = kvs.First();
            var qAmnt = await _currencyConverter.GetConvertQuerryAsync(from.Id, to.Id);
            var dic = new Dictionary<string, double>();
            dic.Add(qAmnt.Key, qAmnt.Value);
            currentKv.LastUpdate = DateTime.Now;
            currentKv.KeyValue = dic;
            await _keyValueStore.Update(currentKv);
            _currentQueryAmount = qAmnt.Value;
            ConvertedAmount = qAmnt.Value * AmountToConvert;
        }

        /// <summary>
        /// Use selected currencies to create query string and amt
        /// </summary>
        void MakeQueryStringAndAmount()
        {
            if (SelectedToCurrency != null && SelectedFromCurrency != null)
            {
                _currentQuery = $"{SelectedFromCurrency.Id}_{SelectedToCurrency.Id}";
                if (SelectedFromCurrency.Id == SelectedToCurrency.Id)
                    _currentQueryAmount = 1;
                else
                    _currentQueryAmount = 0;
            }
        }

        /// <summary>
        /// Convert currencies in realtime
        /// </summary>
        async Task RealtimeConversion()
        {
            if (SelectedToCurrency != null && SelectedFromCurrency != null)
            {
                if (_currentQuery == $"{SelectedFromCurrency.Id}_{SelectedToCurrency.Id}" && _currentQueryAmount > 0)
                {
                    ConvertedAmount = AmountToConvert * _currentQueryAmount;
                }
                else if (!string.IsNullOrEmpty(_currentQuery))
                {
                    var res = _keyValueStore.PersonalizedQuery(kv => kv.KeyValue.First().Key == _currentQuery).Result;
                    if (!res.Any())
                    {
                        ConvertedAmount = 0;
                        return;
                    }
                    try
                    {
                        if ((DateTime.Now - res.First().LastUpdate) > TimeSpan.FromMinutes(1))
                            await UpdateCurrencyConversionRate(res, SelectedFromCurrency, SelectedToCurrency);
                    }
                    catch (HttpRequestException ex)
                    {
                        Debug.WriteLine($"Ignored exception ::: {ex.Message}");
                    }
                    catch(Exception ex)
                    {
                        AppCenterReportException.ReportError(ex, "RealtimeConversion", "MainViewModel");
                    }
                    _currentQueryAmount = res.First().KeyValue.First().Value;
                        ConvertedAmount = AmountToConvert * _currentQueryAmount;
                    
                }
            }
        }

        public async override Task InitializeAsync()
        {
            IsBusy = true;
            
            //check if the database has currencies saved to it
            if ((await _globalCurrenciesStore.Count()) < 1)
            {
                try
                {
                    var currencies = await _currencyConverter.GetAllCurrenciesAsync();
                    await _globalCurrenciesStore.Create(currencies);
                    Currencies = new ObservableCollection<Currency>(currencies.Results.Values);
                    MakeCurrencyStringCollection(Currencies);
                    SetupCurrencies();
                }
                catch (HttpRequestException ex)
                {
                    await _navService.NavigateToNoInternetPopup();
                    Debug.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error occured", ex.Message, "OK");
                    AppCenterReportException.ReportError(ex, "RealtimeConversion", "MainViewModel");
                }
            }
            else
            {
                var currencies = await _globalCurrenciesStore.ReadAll();
                Currencies = new ObservableCollection<Currency>(currencies.First().Results.Values);
                MakeCurrencyStringCollection(Currencies);
                SetupCurrencies();
            }

            IsBusy = false;
            await base.InitializeAsync();
        }
        
        void SetupCurrencies()
        {
            FromCurrencySymbol = "$";
            ToCurrencyIndex = 3;
            FromCurrencyIndex = Currencies.IndexOf(Currencies.Where(_ => _.Id == "USD").First());
            ToCurrencySymbol = Currencies[3].CurrencySymbol ?? Currencies[3].CurrencyName;
            SelectedFromCurrency = Currencies[FromCurrencyIndex];
            SelectedToCurrency = Currencies[ToCurrencyIndex];
        }

        void MakeCurrencyStringCollection(IEnumerable<Currency> currencies)
        {
            foreach(var currency in currencies)
            {
                if (!string.IsNullOrEmpty(currency.CurrencySymbol))
                    StringCurrencies.Add($"({currency.CurrencySymbol}) {currency.CurrencyName}");
                else
                    StringCurrencies.Add($"({currency.Id}) {currency.CurrencyName}");
            }
        }

        public override Task StopAsync()
        {
            Conversions.Clear();
            Conversions = null;
            return base.StopAsync();
        }
    }
}