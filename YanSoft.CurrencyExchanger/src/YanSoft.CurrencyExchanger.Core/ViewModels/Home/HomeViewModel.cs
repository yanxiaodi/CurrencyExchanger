using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using YanSoft.CurrencyExchanger.Core.Common;
using YanSoft.CurrencyExchanger.Core.Models;
using YanSoft.CurrencyExchanger.Core.Services;
using System.Linq;

namespace YanSoft.CurrencyExchanger.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ICurrencyService _currencyService;
        public HomeViewModel(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public override async Task Initialize()
        {
            var service = Mvx.IoCProvider.Resolve<IDataService<CurrencyExchangeItem>>();
            var list = await service.GetAllAsync();
            CurrencyList = new ObservableCollection<CurrencyExchangeBindableItem>(list.ConvertAll((x) => x.ToCurrencyExchangeBindableItem()).OrderBy(x => x.SortOrder));
            //await currencyService.GetCurrencyRates(CurrencyList);
            await base.Initialize();
        }


        #region CurrencyList;
        private ObservableCollection<CurrencyExchangeBindableItem> _currencyList;
        public ObservableCollection<CurrencyExchangeBindableItem> CurrencyList
        {
            get => _currencyList;
            set => SetProperty(ref _currencyList, value);
        }
        #endregion


        #region GetLatestRatesAsyncCommand;

        #region GetLatestRatesTaskNotifier;
        private MvxNotifyTask _getLatestRatesTaskNotifier;
        /// <summary>
        /// Use the IsNotCompleted/IsCompleted properties of the GetLatestRatesTaskNotifier to show an indicator. Using the MvxNotifyTask is a recommended way to use an async command.
        /// </summary>
        /// <value>
        /// The GetLatestRates task notifier.
        /// </value>
        public MvxNotifyTask GetLatestRatesTaskNotifier
        {
            get => _getLatestRatesTaskNotifier;
            set => SetProperty(ref _getLatestRatesTaskNotifier, value);
        }
        #endregion

        private IMvxCommand _getLatestRatesAsyncCommand;
        public IMvxCommand GetLatestRatesAsyncCommand
        {
            get
            {
                _getLatestRatesAsyncCommand = _getLatestRatesAsyncCommand ?? new MvxCommand(() =>
                {
                    GetLatestRatesTaskNotifier = MvxNotifyTask.Create(async () =>
                        {
                            await GetLatestRatesAsync();
                        },
                        OnGetLatestRatesException);
                });
                return _getLatestRatesAsyncCommand;
            }
        }
        private async Task GetLatestRatesAsync()
        {
            // Implement your logic here.
            await _currencyService.GetCurrencyRates(CurrencyList);
            _currencyService.CalculateCurrencyAmount(CurrencyList, CurrencyList.First(x => x.IsStandard));
            await _currencyService.SaveCurrencyData(CurrencyList);
        }

        private void OnGetLatestRatesException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion



        #region RefreshRatesAsyncCommand;

        #region RefreshRatesTaskNotifier;
        private MvxNotifyTask _refreshRatesTaskNotifier;
        /// <summary>
        /// Use the IsNotCompleted/IsCompleted properties of the RefreshRatesTaskNotifier to show an indicator. Using the MvxNotifyTask is a recommended way to use an async command.
        /// </summary>
        /// <value>
        /// The RefreshRates task notifier.
        /// </value>
        public MvxNotifyTask RefreshRatesTaskNotifier
        {
            get => _refreshRatesTaskNotifier;
            set => SetProperty(ref _refreshRatesTaskNotifier, value);
        }
        #endregion

        private IMvxCommand _refreshRatesTaskNotifierAsyncCommand;
        public IMvxCommand RefreshRatesAsyncCommand
        {
            get
            {
                _refreshRatesTaskNotifierAsyncCommand = _refreshRatesTaskNotifierAsyncCommand ?? new MvxCommand(() =>
                {
                    RefreshRatesTaskNotifier = MvxNotifyTask.Create(async () =>
                        {
                            await RefreshRatesAsync();
                        },
                        OnRefreshRatesException);
                });
                return _refreshRatesTaskNotifierAsyncCommand;
            }
        }
        private async Task RefreshRatesAsync()
        {
            // Implement your logic here.
            await GetLatestRatesAsync();
        }

        private void OnRefreshRatesException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion

    }
}
