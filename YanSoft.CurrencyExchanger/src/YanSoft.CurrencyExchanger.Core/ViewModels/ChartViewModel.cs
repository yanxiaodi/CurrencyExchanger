using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;
using System.Linq;
using System.Threading.Tasks;
using YanSoft.CurrencyExchanger.Core.Models.Dto;
using YanSoft.CurrencyExchanger.Core.Utils;
using MvvmCross.Commands;

namespace YanSoft.CurrencyExchanger.Core.ViewModels
{
    public class ChartViewModel : BaseViewModel<CurrencyExchangeBindableItem>
    {


        private readonly ICurrencyService _currencyService;
        private readonly GlobalContext _globalContext;
        private readonly AppSettings _appSettings;

        public ChartViewModel(ICurrencyService currencyService, GlobalContext globalContext, AppSettings appSettings)
        {
            _currencyService = currencyService;
            _globalContext = globalContext;
            _appSettings = appSettings;
            CurrencyList = new ObservableCollection<CurrencyItem>();
            CurrencyRateHistoryItemList = new ObservableCollection<CurrencyRateHistoryItem>();
        }

        


        #region Properties
        #region BaseCurrency;
        private CurrencyItem _baseCurrency;
        public CurrencyItem BaseCurrency
        {
            get => _baseCurrency;
            set => SetProperty(ref _baseCurrency, value);
        }
        #endregion


        #region TargetCurrency;
        private CurrencyItem _targetCurrency;
        public CurrencyItem TargetCurrency
        {
            get => _targetCurrency;
            set => SetProperty(ref _targetCurrency, value);
        }
        #endregion


        #region CurrencyList;
        private ObservableCollection<CurrencyItem> _currencyList;
        public ObservableCollection<CurrencyItem> CurrencyList
        {
            get => _currencyList;
            set => SetProperty(ref _currencyList, value);
        }
        #endregion

        #region SelectedRangeIndex;
        private int _selectedRangeIndex;
        public int SelectedRangeIndex
        {
            get => _selectedRangeIndex;
            set => SetProperty(ref _selectedRangeIndex, value);
        }
        #endregion

        #region RangeList;
        private ObservableCollection<string> _rangeList;
        public ObservableCollection<string> RangeList
        {
            get => _rangeList;
            set => SetProperty(ref _rangeList, value);
        }
        #endregion



        #region CurrencyRateHistoryItemList;
        private ObservableCollection<CurrencyRateHistoryItem> _currencyRateHistoryItemList;
        public ObservableCollection<CurrencyRateHistoryItem> CurrencyRateHistoryItemList
        {
            get => _currencyRateHistoryItemList;
            set => SetProperty(ref _currencyRateHistoryItemList, value);
        }
        #endregion


        #region SelectedItemOpen;
        private string _selectedItemOpen;
        public string SelectedItemOpen
        {
            get => _selectedItemOpen;
            set => SetProperty(ref _selectedItemOpen, value);
        }
        #endregion


        #region SelectedItemClose;
        private string _selectedItemClose;
        public string SelectedItemClose
        {
            get => _selectedItemClose;
            set => SetProperty(ref _selectedItemClose, value);
        }
        #endregion


        #region SelectedItemHigh;
        private string _selectedItemHigh;
        public string SelectedItemHigh
        {
            get => _selectedItemHigh;
            set => SetProperty(ref _selectedItemHigh, value);
        }
        #endregion


        #region SelectedItemLow;
        private string _selectedItemLow;
        public string SelectedItemLow
        {
            get => _selectedItemLow;
            set => SetProperty(ref _selectedItemLow, value);
        }
        #endregion


        #region SelectedItemDateTime;
        private string _selectedItemDateTime;
        public string SelectedItemDateTime
        {
            get => _selectedItemDateTime;
            set => SetProperty(ref _selectedItemDateTime, value);
        }
        #endregion

        #endregion


        #region Lifecycle
        public override async void Prepare(CurrencyExchangeBindableItem parameter)
        {
            await SetCurrenciesAsync(parameter);

            RangeList = new ObservableCollection<string>
            {
                HistoryRange.RangeOneDay,
                HistoryRange.RangeFiveDays,
                HistoryRange.RangeOneMonth,
                HistoryRange.RangeThreeMonths,
                HistoryRange.RangeSixMonths,
                HistoryRange.RangeOneYear,
                HistoryRange.RangeTwoYears
                //HistoryRange.RangeFiveYears
            };
            //SelectedRange = _appSettings.DefaultChartRange;
            SelectedRangeIndex = RangeList.IndexOf(_appSettings.DefaultChartRange);
        }

        private async Task SetCurrenciesAsync(CurrencyExchangeBindableItem parameter)
        {
            var list = await _currencyService.GetAllCurreciesAsync();
            list.Where(x => !x.IsBaseCurrency).ToList().ForEach(x =>
            {
                CurrencyList.Add(x.ToCurrencyExchangeBindableItem().TargetCurrency);
            });
            if (!string.IsNullOrEmpty(parameter.BaseCode) && !string.IsNullOrEmpty(parameter.TargetCode))
            {
                BaseCurrency = _globalContext.CurrentBaseCurrency.BaseCurrency;
                TargetCurrency = CurrencyList.FirstOrDefault(x => x.Code == parameter.TargetCode);
            }
            else
            {
                BaseCurrency = _globalContext.CurrentBaseCurrency.BaseCurrency;
                if (CurrencyList.Any())
                {
                    TargetCurrency = CurrencyList.FirstOrDefault();
                }
            }
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            await GetHistoryRatesAsync();

        }

        private async Task GetHistoryRatesAsync()
        {
            if (CurrencyRateHistoryItemList.Any())
            {
                CurrencyRateHistoryItemList.Clear();
            }
            if (TargetCurrency != null)
            {
                SelectedItemClose = SelectedItemDateTime = SelectedItemHigh = SelectedItemLow = SelectedItemOpen = string.Empty;
                var list = await _currencyService.GetCurrencyRatesHistoryAsync(BaseCurrency, TargetCurrency, RangeList[SelectedRangeIndex]);
                list.ForEach(x =>
                {
                    if (x.High != 0 && x.Low != 0 && x.Open != 0 && x.Close != 0)
                    {
                        x.DateTime = DateTimeHelper.ConvertTimestampToDateTime(x.Timestamp);
                        CurrencyRateHistoryItemList.Add(x);
                    }
                });
            }
        }
        #endregion


        #region Commands

        #region UpdateHistoryRangeAsyncCommand;
        private IMvxAsyncCommand _updateHistoryRangeAsyncCommand;
        public IMvxAsyncCommand UpdateHistoryRangeAsyncCommand
        {
            get
            {
                _updateHistoryRangeAsyncCommand = _updateHistoryRangeAsyncCommand ?? new MvxAsyncCommand(UpdateHistoryRangeAsync);
                return _updateHistoryRangeAsyncCommand;
            }
        }
        private async Task UpdateHistoryRangeAsync()
        {
            // Implement your logic here.
            await GetHistoryRatesAsync();
        }
        #endregion


        #region UpdateTargetCurrencyAsyncCommand;
        private IMvxAsyncCommand _updateTargetCurrencyAsyncCommand;
        public IMvxAsyncCommand UpdateTargetCurrencyAsyncCommand
        {
            get
            {
                _updateTargetCurrencyAsyncCommand = _updateTargetCurrencyAsyncCommand ?? new MvxAsyncCommand(UpdateTargetCurrencyAsync);
                return _updateTargetCurrencyAsyncCommand;
            }
        }
        private async Task UpdateTargetCurrencyAsync()
        {
            // Implement your logic here.
            await GetHistoryRatesAsync();
        }
        #endregion
        #endregion
    }
}
