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
        private readonly ICurrencyService currencyService;
        public HomeViewModel(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public override async Task Initialize()
        {
            var service = Mvx.IoCProvider.Resolve<IDataService<CurrencyExchangeItem>>();
            var list = await service.GetAllAsync();
            //CurrencyList = new ObservableCollection<CurrencyItem>(Mvx.IoCProvider.Resolve<Context>().AllCurrencyItemList);
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
            await currencyService.GetCurrencyRates(CurrencyList);
            currencyService.CalculateCurrencyAmount(CurrencyList, CurrencyList.First(x => x.IsStandard));
            await currencyService.SaveCurrencyData(CurrencyList);
        }

        private void OnGetLatestRatesException(Exception ex)
        {
            // Catch and log the exception here.
        }
        #endregion

    }
}
