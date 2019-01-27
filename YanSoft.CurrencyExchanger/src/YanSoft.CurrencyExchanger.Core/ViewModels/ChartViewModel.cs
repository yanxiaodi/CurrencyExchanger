using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;
using System.Linq;
using System.Threading.Tasks;

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



        //#region SelectedRange;
        //private string _selectedRange;
        //public string SelectedRange
        //{
        //    get => _selectedRange;
        //    set => SetProperty(ref _selectedRange, value);
        //}
        //#endregion


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
        #endregion


        #region Lifecycle
        public override async void Prepare(CurrencyExchangeBindableItem parameter)
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
                TargetCurrency = CurrencyList.FirstOrDefault();
            }

            RangeList = new ObservableCollection<string>
            {
                HistoryRange.RangeOneDay,
                HistoryRange.RangeFiveDays,
                HistoryRange.RangeOneMonth,
                HistoryRange.RangeThreeMonths,
                HistoryRange.RangeSixMonths,
                HistoryRange.RangeOneYear,
                HistoryRange.RangeTwoYears,
                HistoryRange.RangeFiveYears,
                HistoryRange.RangeTenYears
            };
            //SelectedRange = _appSettings.DefaultChartRange;
            SelectedRangeIndex = RangeList.IndexOf(_appSettings.DefaultChartRange);
        }

        public override async Task Initialize()
        {
            await base.Initialize();

        }
        #endregion
    }
}
